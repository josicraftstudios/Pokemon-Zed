using System;
using PokemonMoves;

namespace BattleSystem
{
    public class BattleCode
    {
        while (Enemy[1] > 0 && PlayerHP > 0)
        {
            PlayersTurn = true;
            int Attack = -1;
            while (PlayersTurn)
            {
                for (int i = 0; i < pokemons[Player].Moves.Length; i++)
                {
                    int mi = pokemons[Player].Moves[i];
                    if (mi != -1)
                    {
                        Console.WriteLine((i+1) + ": " + Moves[mi].Name);
                    }
                }
                Attack = Getinput("Choose youre move")-1;
                Attack = Attack<4?pokemons[Player].Moves[Attack]:-1;
                if (Attack != -1)
                {
                    PlayersTurn = false;
                    Console.WriteLine("You Choose " + Moves[Attack].Name);
                }
            }

            //Enemy Pick move
            int EnemyAttack = -1;
            while (EnemyAttack == -1)
            {
                value = rand.Next(0, pokemons[Enemy[0]].Moves.Length);
                EnemyAttack = pokemons[Enemy[0]].Moves[value];
            }
            Console.WriteLine(pokemons[Enemy[0]].Name+" Choose " + Moves[EnemyAttack].Name);
            if (pokemons[Player].Spd >= pokemons[Enemy[0]].Spd)
            {
                Console.WriteLine("You Go First");
                PokemonMoves.RunPlayerAttack(Attack);
                PokemonMoves.RunEnemyAttack(EnemyAttack);
            }
            else
            {
                Console.WriteLine(pokemons[Enemy[0]].Name + " Go First");
                PokemonMoves.RunEnemyAttack(EnemyAttack);
                PokemonMoves.RunPlayerAttack(Attack);
            }
            Console.WriteLine("Player HP: " + PlayerHP + "/"+pokemons[Player].Hp);
            Console.WriteLine(pokemons[Enemy[0]].Name + "HP:" + Enemy[1] +"/"+pokemons[Enemy[0]].Hp);
        }
    }
}
