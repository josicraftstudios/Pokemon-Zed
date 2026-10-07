using System;

namespace PokemonMoves
{
    // 1. Wrap your methods inside a public class
    public class PokeMoves
    {

        void RunPlayerAttack(int move)
        {
            int pow = RunAttack(move, Moves[move].Type, pokemons[Enemy[0]].Type, Player, Enemy[0], PlayerLevel);
            if (pow == -1)
            {
                Console.WriteLine(Moves[move].Name + " missed");
            }
            else
            {
                Enemy[1] -= pow;
                Console.WriteLine("You Deal " + pow + " Damage to " + pokemons[Enemy[0]].Name);
            }
        }

        void RunEnemyAttack(int move)
        {
            int pow = RunAttack(move, Moves[move].Type, pokemons[Player].Type, Enemy[0], Player, Enemy[2]);
            if (pow == -1)
            {
                Console.WriteLine(Moves[move].Name + " missed");
            }
            else
            {
                PlayerHP -= pow;
                Console.WriteLine(pokemons[Enemy[0]].Name + " Deal " + pow + " Damage to You");
            }
        }

        int RunAttack(int move1, Types type1, Types type2, int Poke1, int Poke2, int level)
        {
            bool hit = true;

            if (rand.Next(1, 101) > Moves[move1].Acc) { hit = false; }

            if (hit)
            {
                float effect1 = TypeEffect(type1, type2);
                switch (effect1)
                {
                    case 2f:
                        Console.Write("It's super effective! ");
                        break;

                    case .5f:
                        Console.Write("It's not very effective...");
                        break;

                }
                float powRaw;
                switch (Moves[move1].Cat)
                {

                    case MoveCategory.Special:
                        powRaw = ((((2f * level / 5f) * Moves[move1].Power * pokemons[Poke1].SpecialDefense) / pokemons[Poke2].SpecialDefense) / 50f) + 2f;
                        break;

                    default:
                    case MoveCategory.Physical:
                        powRaw = ((((2f * level / 5f) * Moves[move1].Power * pokemons[Poke1].PhysicalAttack) / pokemons[Poke2].PhysicalDefense) / 50f) + 2f;
                        break;
                }

                int pow = (int)Math.Round(powRaw * effect1);
                if (rand.Next(1, 11) == 1)
                {
                    Console.Write("Its a Crit ");
                    pow *= 2;
                }
                return pow;
            }
            else { return -1; }

        }
    }

}
