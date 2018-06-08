using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashPoker_V2
{
    enum CardSet
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    class CardCounter
    {
        public CardValue value;
        public int amount;

        public CardCounter(CardValue value)
        {
            this.value = value;
            amount = 1;
        }
    }

   

    class CalculateVictor
    {
        public static int GetVictor(Hand[] hands)
        {
            if(CheckForSet(hands[0]) > CheckForSet(hands[1]))
            {
                return 1;
            }
            else if(CheckForSet(hands[0]) < CheckForSet(hands[1]))
            {
                return 2;
            }
            else
            {
                //this is also new
                switch (CheckForSet(hands[0]))
                {
                    case CardSet.HighCard:
                        int handOne = GetHighest(hands[0]);
                        int handTwo = GetHighest(hands[1]);

                        if(handOne > handTwo)
                        {
                            return 1;
                        }
                        else if(handOne < handTwo)
                        {
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    case CardSet.Pair:
                        List<CardCounter> handOneCards = GetAmountOfCards(hands[0]);
                        List<CardCounter> handTwoCards = GetAmountOfCards(hands[1]);

                        //if (handOneCards.Count > 1 || handTwoCards.Count > 1)
                        //{
                        //    Console.WriteLine("Something wrong with pair: " + PlayedHands.currentHand);

                        //    Console.WriteLine("Pair: " + handOneCards[0].value + "   Amount: " + handOneCards[0].amount);
                        //    Console.WriteLine("Pair: " + handOneCards[1].value + "   Amount: " + handOneCards[1].amount);


                        //    Console.WriteLine("Pair: " + handTwoCards[0].value + "   Amount: " + handTwoCards[0].amount);
                        //    Console.WriteLine("Pair: " + handTwoCards[1].value + "   Amount: " + handTwoCards[1].amount);


                        //    do
                        //    {

                        //    }
                        //    while (Console.ReadLine() == "q");
                        //}

                        if (handOneCards[0].value > handTwoCards[0].value)
                        {
                            return 1;
                        }
                        else if (handOneCards[0].value < handTwoCards[0].value)
                        {
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    case CardSet.TwoPair:

                        handOneCards = GetAmountOfCards(hands[0]);
                        handTwoCards = GetAmountOfCards(hands[1]);

                        int[] firstNumbers = new int[2] { (int)handOneCards[0].value, (int)handOneCards[1].value };
                        int[] secondNumbers = new int[2] { (int)handTwoCards[0].value, (int)handTwoCards[1].value };


                        if (firstNumbers[1] > firstNumbers[0])
                        {
                            int temp = firstNumbers[0];
                            firstNumbers[0] = firstNumbers[1];
                            firstNumbers[1] = temp;
                        }

                        if (secondNumbers[1] > secondNumbers[0])
                        {
                            int temp = secondNumbers[0];
                            secondNumbers[0] = secondNumbers[1];
                            secondNumbers[1] = temp;
                        }

                        if (firstNumbers[0] > secondNumbers[0])
                        {
                            return 1;
                        }
                        else if (firstNumbers[0]< secondNumbers[0])
                        {
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    case CardSet.ThreeOfAKind:
                        handOneCards = GetAmountOfCards(hands[0]);
                        handTwoCards = GetAmountOfCards(hands[1]);

                        //if (handOneCards.Count > 1 || handTwoCards.Count > 1)
                        //{
                        //    Console.WriteLine("Something wrong with pair: " + PlayedHands.currentHand);

                        //    Console.WriteLine("Pair: " + handOneCards[0].value + "   Amount: " + handOneCards[0].amount);
                        //    Console.WriteLine("Pair: " + handOneCards[1].value + "   Amount: " + handOneCards[1].amount);


                        //    Console.WriteLine("Pair: " + handTwoCards[0].value + "   Amount: " + handTwoCards[0].amount);
                        //    Console.WriteLine("Pair: " + handTwoCards[1].value + "   Amount: " + handTwoCards[1].amount);


                        //    do
                        //    {

                        //    }
                        //    while (Console.ReadLine() == "q");
                        //}

                        if (handOneCards[0].value > handTwoCards[0].value)
                        {
                            return 1;
                        }
                        else if (handOneCards[0].value < handTwoCards[0].value)
                        {
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    case CardSet.Straight:
                        handOne = CheckForStraight(hands[0]);
                        handTwo = CheckForStraight(hands[1]);

                        if (handOne > handTwo)
                        {
                            return 1;
                        }
                        else if (handOne < handTwo)
                        {
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    case CardSet.Flush:
                        handOne = GetHighest(hands[0]);
                        handTwo = GetHighest(hands[1]);

                        if (handOne > handTwo)
                        {
                            return 1;
                        }
                        else if (handOne < handTwo)
                        {
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    case CardSet.FullHouse:
                        handOneCards = GetAmountOfCards(hands[0]);
                        handTwoCards = GetAmountOfCards(hands[1]);

                        if (handOneCards[0].amount == 3)
                            handOne = (int)handOneCards[0].value;
                        else
                            handOne = (int)handOneCards[1].value;

                        if (handTwoCards[0].amount == 3)
                            handTwo = (int)handTwoCards[0].value;
                        else
                            handTwo = (int)handTwoCards[1].value;

                        if (handOne > handTwo)
                        {
                            return 1;
                        }
                        else if (handOne < handTwo)
                        {
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    case CardSet.FourOfAKind:

                        handOneCards = GetAmountOfCards(hands[0]);
                        handTwoCards = GetAmountOfCards(hands[1]);

                        //if (handOneCards.Count > 1 || handTwoCards.Count > 1)
                        //{
                        //    Console.WriteLine("Something wrong with pair: " + PlayedHands.currentHand);

                        //    Console.WriteLine("Pair: " + handOneCards[0].value + "   Amount: " + handOneCards[0].amount);
                        //    Console.WriteLine("Pair: " + handOneCards[1].value + "   Amount: " + handOneCards[1].amount);


                        //    Console.WriteLine("Pair: " + handTwoCards[0].value + "   Amount: " + handTwoCards[0].amount);
                        //    Console.WriteLine("Pair: " + handTwoCards[1].value + "   Amount: " + handTwoCards[1].amount);


                        //    do
                        //    {

                        //    }
                        //    while (Console.ReadLine() == "q");
                        //}

                        if (handOneCards[0].value > handTwoCards[0].value)
                        {
                            return 1;
                        }
                        else if (handOneCards[0].value < handTwoCards[0].value)
                        {
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    case CardSet.StraightFlush:
                        handOne = CheckForStraight(hands[0]);
                        handTwo = CheckForStraight(hands[1]);

                        if (handOne > handTwo)
                        {
                            return 1;
                        }
                        else if (handOne < handTwo)
                        {
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    case CardSet.RoyalFlush:
                        return 0;
                }

                return 0;
            }
        }
        
        //this is new
        private static int GetHighest(Hand hand)
        {
            CardValue highestCard = CardValue.Two;
            for (int i = 0; i < hand.cards.Count; i++)
            {
                if (i == 0)
                    highestCard = hand.cards[i].value;

                if ((int)hand.cards[i].value > (int)highestCard)
                    highestCard = hand.cards[i].value;
            }

            return (int)highestCard;
        }

        private static CardSet CheckForSet(Hand hand)
        {
            List<CardCounter> counter = GetAmountOfCards(hand);

            //foreach (CardCounter tempCounter in counter)
            //{
            //    Console.WriteLine("Amount: " + tempCounter.amount);
            //}

            #region Pair, TwoPair, FullHouse, FourOfAKind

            foreach (CardCounter tempCounter in counter)
            {
                switch (tempCounter.amount)
                {
                    case 2:

                        foreach (CardCounter secondCounter in counter)
                        {
                            if (tempCounter != secondCounter)
                            {
                                switch (secondCounter.amount)
                                {
                                    case 2:
                                        return CardSet.TwoPair;
                                    case 3:
                                        return CardSet.FullHouse;
                                    default:
                                        break;
                                }
                            }
                        }

                        return CardSet.Pair;
                    case 3:
                        foreach (CardCounter secondCounter in counter)
                        {
                            if (tempCounter != secondCounter)
                            {
                                switch (secondCounter.amount)
                                {
                                    case 2:
                                        return CardSet.FullHouse;
                                    default:
                                        break;
                                }
                            }
                        }

                        return CardSet.ThreeOfAKind;
                    case 4:
                        return CardSet.FourOfAKind;
                    default:
                        break;
                }
            }

            #endregion


            if (CheckForFlush(hand))
            {
                if (CheckForStraight(hand) > 0)
                {
                    if (CheckForStraight(hand) == (int)CardValue.Ace)
                    {
                        return CardSet.RoyalFlush;
                    }
                    else
                    {
                        return CardSet.StraightFlush;
                    }
                }
                else
                {
                    return CardSet.Flush;
                }
            }
            else
            {
                if (CheckForStraight(hand) > 0)
                {
                    return CardSet.Straight;
                }
                else
                {
                    return CardSet.HighCard;
                }
            }
        }

        private static int CheckForStraight(Hand hand)
        {
            CardValue highestCard = 0;
            //int failSave = temp;
            

            for (int i = 0; i < hand.cards.Count; i++)
            {
                if (i == 0)
                {
                    highestCard = hand.cards[i].value;
                }
                else if (hand.cards[i].value > highestCard)
                {
                    highestCard = hand.cards[i].value;
                }
            }


            // failSave = temp - 4;
            //foreach (Card card in hand.cards)
            // {
            //     int failed = 0;

            //     if ((int)card.value != temp)
            //     {
            //         for (int j = 0; j < hand.cards.Count; j++)
            //         {
            //             if ((int)hand.cards[j].value != temp)
            //             {
            //                 if (((int)hand.cards[j].value) == temp - 1)
            //                 {
            //                     temp--;
            //                 }
            //                 else { failed++; }
            //             } else if (temp == failSave)
            //             {
            //                 failed--;
            //             }

            //             if (failed == (hand.cards.Count - 1))
            //             {
            //                 return 0;
            //             }
            //         }
            //     }
            // }

            // return temp;

            CardValue currentHighest = highestCard;
            int amount = 1;

            foreach (Card card in hand.cards)
            {
                if (card.value != highestCard)
                {
                    foreach (Card secondaryCard in hand.cards)
                    {
                        if ((int)secondaryCard.value == (int)currentHighest - 1)
                        {
                            amount += 1;
                            currentHighest = secondaryCard.value;
                            break;
                        }
                    }
                }
            }

            if (amount == 5)
            {
                return (int)highestCard; //returns
            }
            else return 0;
        }

        private static bool CheckForFlush(Hand hand)
        {
            CardType temp = CardType.Clubs;

            for (int i = 0; i < hand.cards.Count; i++)
            {
                if (i == 0)
                {
                    temp = hand.cards[i].type;
                }
                else if (hand.cards[i].type != temp)
                {
                    return false;
                }
            }

            return true;
        }

        private static List<CardCounter> GetAmountOfCards(Hand hand)
        {
            List<CardCounter> cardCounter = new List<CardCounter>();

            foreach (Card card in hand.cards)
            {
                bool added = false;

                if (cardCounter.Count > 0)
                {
                    foreach (CardCounter counter in cardCounter)
                    {
                        if (!added)
                        {
                            if (counter.value == card.value)
                            {
                                counter.amount++;
                                added = true;
                            }
                        }
                    }
                }

                if (!added)
                {
                    cardCounter.Add(new CardCounter(card.value));
                }
            }
            List<CardCounter> toRemove = new List<CardCounter>();

            foreach (CardCounter counter in cardCounter)
            {
                if (counter.amount < 2)
                {
                    toRemove.Add(counter);
                }
            }

            foreach (CardCounter counter in toRemove)
            {
                cardCounter.Remove(counter);
            }

            return cardCounter;
        }
    }
}
