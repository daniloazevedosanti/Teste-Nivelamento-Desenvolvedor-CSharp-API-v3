using Newtonsoft.Json;
using Questao2;
using System.Net;
using System.Text.Json.Nodes;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        var requisicaoWeb = WebRequest.CreateHttp("https://jsonmock.hackerrank.com/api/football_matches?year="+year+"&team1="+team);
        requisicaoWeb.Method = "GET";
        requisicaoWeb.UserAgent = "RequisicaoWebDemo";

        int totalgols = 0;

        using (var resposta = requisicaoWeb.GetResponse())
        {
            var streamDados = resposta.GetResponseStream();
            StreamReader reader = new StreamReader(streamDados);
            JsonNode objResponse = reader.ReadToEnd();

            var post = JsonConvert.DeserializeObject<Footballchamps>(objResponse.ToString());
            
            foreach (Team item in post.data)
            {
                totalgols += item.team1goals;
            }

            Console.ReadLine();
            streamDados.Close();
            resposta.Close();
            
        }

        return totalgols;
    }

}