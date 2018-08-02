namespace MemontoPatternDemo
{
    public class Originator
    {
        public string PowerState { get; set; }
        public string DefenseState { get; set; }

        public Menento CreateMenento()
        {
            return new Menento(PowerState,DefenseState);
        }

        public void SetMenento(Menento menento)
        {
            PowerState = menento.PowerState;
            DefenseState = menento.DefenseState;
        }
    }
}
