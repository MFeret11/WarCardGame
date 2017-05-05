using System;
using System.Collections.Generic;

namespace WarCardGame
{
	public class Rank
	{
		string rankName;
		int rankRank;
		string rankSymbol;

		public static Rank TWO = new Rank ("TWO", 2,"2");
		public static Rank THREE = new Rank ("THREE",3, "3");
		public static Rank FOUR = new Rank ("FOUR",4, "4");
		public static Rank FIVE = new Rank ("FIVE",5, "5");
		public static Rank SIX = new Rank ("SIX",6, "6");
		public static Rank SEVEN = new Rank ("SEVEN",7, "7");
		public static Rank EIGHT = new Rank ("EIGHT",8, "8");
		public static Rank NINE = new Rank ("NINE",9, "9");
		public static Rank TEN = new Rank ("TEN",10, "10");
		public static Rank JACK = new Rank ("JACK",11, "J");
		public static Rank QUEEN = new Rank ("QUEEN",12, "Q");
		public static Rank KING = new Rank ("KING",13, "K");
		public static Rank ACE = new Rank ("ACE",14, "A");

		public static List<Rank> VALUES = new List <Rank> ()
		{
			TWO,THREE,FOUR,FIVE,SIX,SEVEN,EIGHT,NINE,TEN,JACK,QUEEN,KING,ACE
		};

		public Rank(string name, int rank, string symbol){
			rankName = name;
			rankRank = rank;
			rankSymbol = symbol;
		}

		//Methods

		public int CompareTo(Rank otherRank){ 
			int value = -5;
			if (this.rankRank > otherRank.rankRank)
				value = 1;
			else if (this.rankRank < otherRank.rankRank)
				value = -1;
			else
				value = 0;
			return value;
		}

		public string GetSymbol(){				
			return rankSymbol;
		}

		public string GetName(){
			return rankName;
		}

		public override string ToString (){
			return rankSymbol;
		}
	}
}

