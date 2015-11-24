namespace BasciTest.Tests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal class Logik
    {

        public static Logik Instance => new Logik();

        public int Num = 2;

        public Logik()
        {
            var refNum = new Termcontent {Referencnumber = 1};

            DoOutput(refNum);
            DoOutputsimple(Num);

            
        }

        public void DoOutputsimple(int num)
        {
            var result = num + num;
            num = 0;
        }

        public void DoOutput(Termcontent refNum)
        {
            var result = refNum.Referencnumber * 2;
            refNum.Referencnumber = 0; 
        }

        
    }
}
