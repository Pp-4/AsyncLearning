using System.Collections;
using static System.Console;
namespace AsyncLearning.Examples;

//Ten przykład demonstruje iterację 'kolekcji' klas typu Tank 
public static class ImplementacjaWłasnegoEnumeratora
{
    public static void Run()
    {
        Tanks tanks = new([new("T-34", 85, 30, 45), new("Panzer 4G", 75, 32, 50)]);
        foreach (Tank tank in tanks)
        {
            WriteLine(tank);
        }
    }
}
public class Tank(string Model, int CanonSize, int Speed, int Armor)
{
    readonly string Model = Model;
    readonly int CanonSize = CanonSize;
    readonly int Speed = Speed;
    readonly int Armor = Armor;
    public override string ToString() => $"Model: {Model}, Canon size: {CanonSize} mm, Max speed: {Speed} kph, Front armor: {Armor} mm";
}

public class Tanks(List<Tank> _TankList) : IEnumerable<Tank>
{
    // no wiem, użycie listy w tym miejscu jest śmieszne biorąc pod uwagę implementację własnej enumeracji, ale to dla nauki
    private readonly List<Tank> _TankList = _TankList;

    //IEnumearable mówi "Hej, jestem kolekcją którą da się przeiterować"
    public IEnumerator<Tank> GetEnumerator() => new TankEnumerator(_TankList);

    //Wymage dla niegenerycznych enumeratorów, i dla kompatybilności wstecznej czy coś
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    class TankEnumerator(List<Tank> _TankList) : IEnumerator<Tank>
    {
        //iterator
        private int _Current = -1;

        //zwraca obecną iterację
        public Tank Current => _TankList[_Current];

        //przechodzi do następnego elementu kolekcji
        public bool MoveNext() => ++_Current < _TankList.Count();

        //resetuje iteratora do pierwszej pozycji
        public void Reset() => _Current = 0;

        //Znowu, dla typów niegenerycznych i dla kompatybilności wstecznej
        object IEnumerator.Current => Current;
        public void Dispose() { }
    }
}