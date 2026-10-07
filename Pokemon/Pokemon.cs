public class Pokemon
{
    public string Name;
    public Types Type;
    public int Hp;
    public int Spd;
    public int[] Moves;
    public int PhysicalAttack;
    public int SpecialAttack;
    public int PhysicalDefense;
    public int SpecialDefense;

    public Pokemon(string name, Types Typeing, int Health, int Speed, int[] Attacks, int At, int SAt, int Df, int SDf)
    {
        Name = name;
        Type = Typeing;
        Hp = Health;
        Spd = Speed;
        Moves = Attacks;
        PhysicalAttack = At;
        SpecialAttack = SAt;
        PhysicalDefense = Df;
        SpecialDefense = SDf;
    }
}

public enum Types { Normal, Fire, Water, Grass };
public enum MoveCategory { Physical, Special, Status };

public class Abilety
{
    public string Name;
    public Types Type;
    public MoveCategory Cat;
    public int Power;
    public int Acc;

    public Abilety(string name, Types Typeing, MoveCategory Category, int Damage, int HitChance)
    {
        Name = name;
        Type = Typeing;
        Cat = Category;
        Power = Damage;
        Acc = HitChance;
    }
}
