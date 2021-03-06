﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace WarCardGame
{

	public class WarGame
	/* Rules: 52 normal card deck. each player starts with 26 cards, face down. 
	 * In unison, players flip cards to reveal the top card 1 at a time.
	 * If player A's card has a higher rank than player B's card, (2-A) player A's 
	 * gets both cards and places them at the bottom of their hand.
	 * If the cards are the same value both players place 3 cards face-down and 
	 * flip and compare a fourth card. Whomever has the greater ranking card between 
	 * the two wins all the cards in that round. Game ends when 1 player runs out of cards.
	 * thus, other player wins.
	 * Written by: Mattthew Feret
	 * */
		
	{
		private const int NUM_OF_CARDS = 52;
		private const int MAXROUNDS = 500;

		static WarGame ()
		{
			Console.WriteLine ("\n\nLET'S HAVE A WAR!!!\n");

			Deck newDeck = new Deck ();
			populateDeck (newDeck);

			//Deal 26 cards to each player.
			List<Card> player1Hand = new List <Card> (){ };
			for (int i = 0; i < (NUM_OF_CARDS / 2); i++) {
				Card c = newDeck.DealOne ();
				player1Hand.Add (c);
			}				
			List<Card> player2Hand = new List <Card> (){ };
			for (int i = 0; i < (NUM_OF_CARDS / 2); i++) {
				Card c = newDeck.DealOne ();
				player2Hand.Add (c);
			}
				
			Console.WriteLine ("Initial card count: ");
			Console.WriteLine ("player 1 has " + player1Hand.Count + " Cards");
			Console.WriteLine ("player 2 has " + player2Hand.Count + " Cards");

			//compare cards
			const int drawForTie = 4;
			int tie = 1;
			string input;
			for (int i = 0; i < MAXROUNDS; i++) {
				//either player is out of cards
				if (!player1Hand.Any () || !player2Hand.Any ()) {
					Console.WriteLine ("Game Over!");
					if (!player1Hand.Any ()) {
						Console.WriteLine ("Player 2 Wins!");
						Console.WriteLine ("Press Y to see final winning hand: ");
						input = Console.ReadLine ().ToUpper ();
						if (input == "Y") {
							Console.WriteLine ("------------------");
							foreach (Card c in player2Hand) {
								Console.WriteLine (c.ToString () + " ");
							}
						}
						Console.WriteLine ("------------------");
						Console.WriteLine ("Thanks!");
					}
					if (!player2Hand.Any ()) {
						Console.WriteLine ("Player 1 Wins!");
						Console.WriteLine ("Press y to see final winning hand: ");
						input = Console.ReadLine ().ToUpper ();
						if (input == "Y") {
							Console.WriteLine ("------------------");
							foreach (Card c in player1Hand) {
								Console.WriteLine (c.ToString () + " ");
							}
						}
						Console.WriteLine ("------------------");
						Console.WriteLine ("Thanks!");
					}
					return;
				} else { //else both players have some cards
					if (player1Hand [i % player1Hand.Count].Equals (null) || player2Hand [i % player2Hand.Count].Equals (null)) {
						Console.WriteLine ("Game Over2!");
						return;
					} else { //both players have a card in i position. Game is on.
						Console.WriteLine ("----------------------");
						Console.WriteLine ("Round " + (i + 1) + ":");
						//COMPARE
						//player1 card is stronger
						if (compareCards (player1Hand [i % player1Hand.Count], player2Hand [i % player2Hand.Count]) == 1) {
							Console.WriteLine ("Player 1 wins this round.");
							player1Hand.Add (player2Hand [i % player2Hand.Count]); //player1 gets card.
							player2Hand.RemoveAt (i % player2Hand.Count); // remove card
							Console.WriteLine (player1Hand [player1Hand.Count - 1].ToString ());

							Console.WriteLine ("player 1 has " + player1Hand.Count + " Cards");
							Console.WriteLine ("player 2 has " + player2Hand.Count + " Cards");

						} //player 2 card is stronger
						else if (compareCards (player1Hand [i % player1Hand.Count], player2Hand [i % player2Hand.Count]) == -1) {
							Console.WriteLine ("Player 2 wins this round.");
							player2Hand.Add (player1Hand [i % player1Hand.Count]); //player2 gets card.
							player1Hand.RemoveAt (i % player1Hand.Count); //remove card
							Console.WriteLine (player2Hand [player2Hand.Count - 1].ToString ()); //print card that transfers hands

							Console.WriteLine ("player 1 has " + player1Hand.Count + " Cards");
							Console.WriteLine ("player 2 has " + player2Hand.Count + " Cards");
						} //else are equal 
					else {
							Console.WriteLine ("Round is a Tie");
							//run for however many ties you have
							for (int j = 0; j < tie; j++) {

								// first check if either player is nearly out of cards
								if (player1Hand.Count - (drawForTie * tie) <= 0) {
									Console.WriteLine ("player 1 has " + player1Hand.Count + " Cards");
									Console.WriteLine ("Not enough for tiebreaker. \n Player 2 wins!");
									return;
								} else if (player2Hand.Count - (drawForTie * tie) <= 0) {
									Console.WriteLine ("player 2 has " + player2Hand.Count + " Cards");
									Console.WriteLine ("Not enough for tiebreaker. \n Player 1 wins!");
									return;
								} else if (compareCards (player1Hand [((i + (drawForTie * tie)) % player1Hand.Count)], player2Hand [((i + (drawForTie * tie)) % player2Hand.Count)]) == 1 ||
								           compareCards (player1Hand [((i + (drawForTie * tie)) % player1Hand.Count)], player2Hand [((i + (drawForTie * tie)) % player2Hand.Count)]) == -1) {
									//Cards are not equal. Compare cards in 4th, then 8th, then 12th... position
									if (compareCards (player1Hand [((i + (drawForTie * tie)) % player1Hand.Count)], player2Hand [((i + (drawForTie * tie)) % player2Hand.Count)]) == 1) { //player1 wins
										//player1 wins a bunch of cards & player2 loses a bunch
										if(tie == 1)
											Console.WriteLine ("Player 1 wins tiebreaker!");
										else if( tie == 2)
											Console.WriteLine ("Player 1 wins double - tiebreaker!");
										else if(tie >= 3)
											Console.WriteLine ("Player 1 wins triple - tiebreaker!");
										
										Console.WriteLine ("Recieves " + (drawForTie * tie + 1) + " Cards");
									
										for (int k = 0; k <= drawForTie * tie; k++) {
											player1Hand.Add (player2Hand [((i + k) % player2Hand.Count)]);
											Console.WriteLine (player1Hand.Last().ToString());
											player2Hand.Remove (player2Hand [((i + k) % player2Hand.Count)]);
										}

									
										Console.WriteLine ("Player 1 Count: " + player1Hand.Count);
										Console.WriteLine ("Player 2 Count: " + player2Hand.Count);

									} else {
										//player2 wins a bunch and player2 loses a bunch
										if(tie == 1)
											Console.WriteLine ("Player 2 wins tiebreaker!");
										else if( tie == 2)
											Console.WriteLine ("Player 2 wins double - tiebreaker!");
										else if(tie >= 3)
											Console.WriteLine ("Player 2 wins triple (or higher!) tiebreaker!");
										
										Console.WriteLine ("Recieves " + (drawForTie * tie + 1) + " Cards: ");
										Console.WriteLine ("Player 1 Count: " + player1Hand.Count);
										Console.WriteLine ("Player 2 Count: " + player2Hand.Count);

										for (int k = 0; k <= drawForTie * tie; k++) {
											player2Hand.Add (player1Hand [((i + k) % player1Hand.Count)]);
											Console.WriteLine (player2Hand.Last().ToString());
											player1Hand.Remove (player1Hand [((i + k) % player1Hand.Count)]);
										}
										Console.WriteLine ("Player 1 Count: " + player1Hand.Count);
										Console.WriteLine ("Player 2 Count: " + player2Hand.Count);
									}
								} else {	//Cards are equal so we must do another tie-breaker
									Console.WriteLine("tie-breaker #" +(tie+1)+"!");
									tie++;
								}
							}//reset tie
							tie = 1;
						}
					}
				}
			}
			Console.WriteLine ("----------------------");
			Console.WriteLine ("----------------------");
			Console.WriteLine ("Result: ");

			Console.WriteLine ("player 1 has " + player1Hand.Count + " Cards");
			Console.WriteLine ("player 2 has " + player2Hand.Count + " Cards");
			//Console.WriteLine ("Total: " + (player1Hand.Count + player2Hand.Count) + " Cards");
			Console.WriteLine ("\n");

			//decide winner!
			if (player1Hand.Count > player2Hand.Count)
				Console.WriteLine ("Player 1 wins!");
			else if (player1Hand.Count < player2Hand.Count)
				Console.WriteLine ("Player 2 wins!");
			else
				Console.WriteLine ("Tie! -- After " + MAXROUNDS + " rounds!!!");
		}


		public static int compareCards (Card a, Card b)
		{
			//player1 card is stronger
			if (a.CompareTo (b) == 1) {
				return 1;
			} //player 2 card is stronger
			else if (a.CompareTo (b) == -1) {
				return -1;
			} else {
				return 0;
			}
		}


		public static Deck populateDeck (Deck newDeck)
		{
			for (int x = 0; x < Suit.VALUES.Count; x++) {
				for (int y = 0; y < Rank.VALUES.Count; y++) {
					Card card = new Card (Suit.VALUES [x], Rank.VALUES [y]);
					newDeck.AddCard (card);
				}
			}
			newDeck.Shuffle ();
			return newDeck;
		}

		public static void PlayGame (){}
	}
}

