using System;

namespace WarCardGame
{
	public class Card
	{


			private Suit suit;
			private Rank rank;

			public Card (Suit cardSuit, Rank cardRank)
			{
				suit = cardSuit;
				rank = cardRank;
			}

			//Methods
			public int CompareTo(Card otherCard){ 
				int value = 5;

				if (this.rank.CompareTo (otherCard.rank) == 0)
					value = 0; //cards are of the same rank
				else if (this.rank.CompareTo (otherCard.rank) == -1)
					value = -1; //card 1 is weaker than card 2
				else //card 1 is stronger
					value = 1;

				return value;
			}
			public string GetRank(){
				return rank.ToString();
			}
			public string GetSuit(){
				return suit.ToString();
			}

			public override string ToString ()
			{
				return rank + " of " + suit;
			}
		}
}

