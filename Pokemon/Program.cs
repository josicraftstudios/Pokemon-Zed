using PokemonMoves;
using BattleCode;

public Pokemon[] pokemons = {
    new Pokemon("Charmander", Types.Fire, 39, 65, [0, 1, -1, -1],52,60,43,50),
    new Pokemon("Squirtle", Types.Water, 45, 45, [0, 3, -1, -1],49,65,49,65),
    new Pokemon("Bulbasaur", Types.Grass, 44, 43, [0, 2, -1, -1],48,50,65,64),
    new Pokemon("Rattata", Types.Normal, 30, 72, [0, 4, 5, -1],56,25,35,35)
};

public Abilety[] Moves = {
    new Abilety("Scratch",Types.Normal,MoveCategory.Physical,40,100),
    new Abilety("Ember",Types.Fire,MoveCategory.Special,40,100),
    new Abilety("Vine Whip",Types.Grass,MoveCategory.Physical,40,90),
    new Abilety("Bubble",Types.Water,MoveCategory.Special,40,100),
    new Abilety("Quick Attack",Types.Normal,MoveCategory.Physical,40,100),
    new Abilety("Tail Whip", Types.Normal, MoveCategory.Physical, 50, 75),
};

int Getinput(string text) {

    int result;
    Console.WriteLine(text);
    while (!int.TryParse(Console.ReadLine(),out result)){
        Console.WriteLine("Try a nummber");
    }
    return result;

}

//Pokemon Choices
for (var i = 0; i < pokemons.Length; i++)
{
    Console.WriteLine((i+1) + ": " + pokemons[i].Name + "-" + pokemons[i].Type);
}


//Player choose pokemon
int Player = -1;
int PlayerLevel = 5;
while (Player == -1)
{

    Player = Getinput("Choose Youre Pokemon") - 1;
    if (Player < pokemons.Length && Player >= 0)
    {
        Console.WriteLine("You picked " + pokemons[Player].Name);
    }
    else
    {
        Console.WriteLine("Lets try agin with one of the Options");
        Player = -1;
    }
}

//Setyp for Fight
int[] Enemy = new int[4];
public Random rand = new Random();
int value = rand.Next(0,pokemons.Length);
Enemy[0] = value;
Enemy[2] = 5;
Enemy[1] = calculateHP(Enemy[0], Enemy[2]);
Enemy[3] = Enemy[1];

int PlayerHP = calculateHP(Player, PlayerLevel);
int PlayerHPMax = PlayerHP;

Console.WriteLine("You will face a " + pokemons[Enemy[0]].Name);

bool PlayersTurn = true;




float TypeEffect(Types attacker, Types defender)
{
    float[,] typeEffectArray =
    {
        // Defender: Normal, Fire, Water, Grass
        { 1f, 1f, 1f, 1f },  // Normal
        { 1f, 1f, 0.5f, 2f }, // Fire
        { 1f, 2f, 1f, 0.5f }, // Water
        { 1f, 0.5f, 2f, 1f }  // Grass
    };

    return typeEffectArray[(int)attacker, (int)defender];
}

int calculateHP(int Poke1, int level){
    float Raw = (2f * pokemons[Poke1].Hp * level)/100;
    int outHP = (int)Raw+level+10;
    return outHP;
}
