using System;
using System.Collections.Generic;
using System.Linq;

namespace WarCardGame
{
	public abstract class Hand
	{
		public static List<Card> HAND = new List <Card> ()
		{};
		public Hand ()
		{}
		public Hand (List<Card> cardsInHand)
		{HAND = cardsInHand;}

		public void AddCard(Card c){
			HAND.Add(c);
		}
		public abstract int CompareTo (Hand OtherHandObject);


		public bool ContainsCard(Card currCard){
			if (HAND.Contains (currCard))
				return true;
			return false;
		}
		public void DiscardHand(){
			HAND.Clear();
		}
		int FindCard(Card currCard){
			return HAND.IndexOf (currCard);
		}
		public Card GetCardAtIndex(int i){
			return HAND.ElementAt (i);
		}
		public int GetNumberOfCards(){
			return HAND.Count;
		}
		public bool IsEmpty(){
			if (HAND.Count == 0)
				return true;
			else
				return false;
		}
		public Card RemoveCard(Card toRemove){
			HAND.Remove (toRemove);
			return toRemove;
		}
		public Card RemoveCard(int i){
			Card doomedCard = HAND.ElementAt (i); 
			HAND.RemoveAt (i);
			return doomedCard;
		}
		public abstract int EvaluateHand ();

		public override string ToString (){
			System.Text.StringBuilder result = new System.Text.StringBuilder();
			string cardString;
			//int handNum = 0;

			foreach (Card c in HAND)
			{
				Console.Write ("{0} of {1} ", c.GetSuit (), c.GetRank ());
				cardString = c.GetRank () +" of "+ c.GetSuit () + "\n";
				result.AppendLine(cardString); 

			}
			return result.ToString();
		}
	}
}

