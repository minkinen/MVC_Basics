namespace MVC_Basics.Models
{
    public class DoctorModel
    {
        public static string WriteMessage()
        {
            return "Please enter your temperature:";
        }

        public static string FeverCheck(string temperature)
        {
            string tempDecimalPointFormat = temperature.Replace(".", ",");
            float temperatureValue = float.Parse(tempDecimalPointFormat);
            if (temperatureValue >= 37.2)
                return "You have a " + temperature + "°C fever!";
            else
                if (temperatureValue < 35)
                    return "Your " + temperature + "°C cold body suffers from hypothermia!";
                else
                    return "You have a healthy body temperature of " + temperature + "°C!";
        }

    }
}
