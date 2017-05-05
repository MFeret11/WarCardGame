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
			int value = -5;

			if (this.rank.CompareTo (otherCard.rank) == 0 && this.suit.CompareTo (otherCard.suit) == 0)
				value = 0; //cards are the same
			else if (this.rank.CompareTo (otherCard.rank) == 0 && this.suit.CompareTo (otherCard.suit) == -1)
				value = -1;
			else if (this.rank.CompareTo (otherCard.rank) == -1)
				value = -1;
			else
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

