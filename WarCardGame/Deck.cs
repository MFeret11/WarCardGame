using System;
using System.Collections.Generic;
using System.Linq;

namespace WarCardGame
{
	public class Deck
	{

		static Random randomNum = new Random();
		public int newSuit = randomNum.Next(0, 3);
		public int newRank = randomNum.Next(0, 12);

		public Deck (){}

		public static List<Card> CARDDECK = new List <Card> ()
		{};
		public static List<Card> DEALT = new List <Card> ()
		{};

		public Deck (List<Card> cardsInDeck)
		{
			CARDDECK = cardsInDeck;
		}
		//Methods
		public void AddCard(Card currCard){
			CARDDECK.Add (currCard);
		}
		public Card DealOne(){ //set card to first in list. add to DEALT. remove from list. return card.
			Card dealt = CARDDECK.First();
			DEALT.Add (dealt);
			CARDDECK.RemoveAt (0);
			return dealt;
		}
		public int GetCardsRemaining(){
			return CARDDECK.Count - DEALT.Count;

		}
		public int GetDeckSize(){
			return CARDDECK.Count;
		}
		public bool IsEmpty(){
			if (CARDDECK.Count == 0)
				return true;
			else
				return false;
		}
		public void Shuffle()
		{
			int n = CARDDECK.Count;
			Random range = new Random();
			while (n > 1) {
				int i = (range.Next (0, n) % n);
				n--;
				Card value = CARDDECK [i];
				CARDDECK [i] = CARDDECK [n];
				CARDDECK [n] = value;
			}
		}
		public void RestoreDeck(){
			foreach(Card c in DEALT){
				CARDDECK.Add (c);
			}
		}
	}
}

