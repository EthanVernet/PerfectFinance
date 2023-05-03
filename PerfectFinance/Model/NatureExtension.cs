using System.Dynamic;

namespace Logic
{
    public static class NatureExtension
    {
        public static Nature GetById(int id)
        {
            switch (id)
            {
                default: return Nature.CHEQUE;
                case 2: return Nature.ESPECE;
                case 3: return Nature.CARTE;
            }
        }
    }

    public enum Nature
    {
        CHEQUE,
        ESPECE,
        CARTE
    }
}
