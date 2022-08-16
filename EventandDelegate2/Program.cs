namespace EventandDelegate2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UnitChecker unitChecker = new UnitChecker();
            unitChecker.ActOnUnitFinished();
        }
    }
    internal class Phcn  //publisher
    {
        public delegate void NotifyHandler();
        public event NotifyHandler NotifyOtherClasses;

        public void UnitDetector()
        {

            Console.WriteLine("How many units do you have?");
            int unit = int.Parse(Console.ReadLine());
            for (int i = unit; i > -1; i-=10)
            {
                Console.WriteLine("You have this amount of unit left: \n" + i);
                if (i == 0)
                {
                    UnitFinished();
                }
                               
            }
            

        }
        protected virtual void UnitFinished()
        {
            NotifyOtherClasses?.Invoke();  //raise event
        }

    }
    
    public class UnitChecker   //subscriber
    {
        public void ActOnUnitFinished()
        {
            var phcn = new Phcn();
            phcn.NotifyOtherClasses += UnitActions;


            phcn.UnitDetector();
        }



        public void UnitActions()
        {
            Console.WriteLine("You do not have any unit left");
            Console.ReadLine();
        }
    }

}