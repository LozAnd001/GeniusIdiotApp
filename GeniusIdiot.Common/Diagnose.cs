namespace GeniusIdiot.Common
{
    public class Diagnose
    {
        public static string Calculate(int countRightAnswers, int countQuestions)
        {
            var diagnoses = GetAll();
            var percentRightAnswers = countRightAnswers * 100 / countQuestions;
            
            return diagnoses[percentRightAnswers / 20];
        }

        static string[] GetAll()
        {
            var diagnoses = new string[6];
            diagnoses[0] = "кретин";
            diagnoses[1] = "идиот";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";
            return diagnoses;
        }
    }
}