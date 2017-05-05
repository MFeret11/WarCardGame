using System;
using System.Collections.Generic;

namespace WarCardGame
{
	public class Suit
	{
		string suitName;
		int suitRank;
		string suitSymbol;

		public static Suit CLUBS = new Suit ("CLUBS",1,"C");
		public static Suit DIAMONDS = new Suit ("DIAMONDS",2,"D");
		public static Suit HEARTS = new Suit ("HEARTS",3,"H");
		public static Suit SPADES = new Suit ("SPADES",4,"S");

		public static List<Suit> VALUES = new List <Suit> ()
		{
			CLUBS,HEARTS,DIAMONDS,SPADES
		};

		public Suit(string name, int sRank, string symbol){
			suitName = name;
			suitRank = sRank;
			suitSymbol = symbol;
		}

		public int CompareTo(Suit otherSuit){
			int value = -5;
			if (this.suitRank > otherSuit.suitRank)
				value = 1;
			else if (this.suitRank < otherSuit.suitRank)
				value = -1;
			else
				value = 0;
			return value;
		}
		string GetSymbol(){
			return suitSymbol;
		}
		string GetName(){
			return suitName;
		}
		public override string ToString (){
			return suitName;
		}

	}
}

