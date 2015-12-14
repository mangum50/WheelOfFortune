using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WheelOfFortune
{
    public partial class Board : Form
    {
        public List<String> words = new List<String>();
        public List<String> phrases = new List<String>();
        public Random myRand = new Random();
        public List<char> choice = new List<char>();
        public ArrayList Brain = new ArrayList();
        public List<char> alphabet = new List<char>();
        public char currLetter = 'a';
        public string result;
        private Dictionary<int, CommonCount> wordCommonalities = new Dictionary<int, CommonCount>();
        private Dictionary<int, CommonCount> phraseCommonalities = new Dictionary<int, CommonCount>();
        keyboard letters = new keyboard();
        public int numberFound = 0;
        public List<String> phrasesTried = new List<String>();

        public Board()
        {
            InitializeComponent();
            getWords();
            getPhrases();
            populateAlphabet();
            selectNewPhrase();
            CreateBrain();        
        }
        public void getWords()
        {
            string line;
            int counter = 0;
            StreamReader wordIn = new StreamReader(@"CommonWordCount.txt");
            while ((line = wordIn.ReadLine()) != null)
            {
                int i = 0;
                char findFirstChar = ' ';
                string count = "";
                while (Char.IsDigit(findFirstChar) || findFirstChar == ' ')
                {
                    findFirstChar = line[i];
                    i++;
                    if (Char.IsDigit(findFirstChar))
                    {
                        count += findFirstChar;
                    }
                }
                line = line.Remove(0, i - 1);
                CommonCount wordPair = new CommonCount(line, Int32.Parse(count));
                wordCommonalities.Add(counter, wordPair);
                words.Add(line);
                counter++;
            }
            words.Sort();
            wordIn.Close();
            
        }

        public void getPhrases()
        {
            //phrases are http://bb.evilpettingzoo.com:81/wheel/
            //accessed 11/19/2015
            string line;
            int counter = 0;
            StreamReader phraseIn = new StreamReader(@"CommonPhraseCount.txt");
            while ((line = phraseIn.ReadLine()) != null)
            {
                int i = 0;
                char findFirstChar = ' ';
                string count = "";
                while (Char.IsDigit(findFirstChar) || findFirstChar == ' ')
                {
                    findFirstChar = line[i];
                    i++;
                    if (Char.IsDigit(findFirstChar))
                    {
                        count += findFirstChar;
                    }
                }
                line = line.Remove(0, i-1);
                CommonCount phrasePair = new CommonCount(line, Int32.Parse(count));
                phraseCommonalities.Add(counter, phrasePair);
                phrases.Add(line);
                counter++;
            }
            phrases.Sort();
            phraseIn.Close();
            
        }

        public void populateAlphabet()
        {
            for (char let = 'a'; let <= 'z'; let++)
            {
                alphabet.Add(let);
            }
        }
        public void storePhrases()
        {
            StreamWriter phraseOut = new StreamWriter(@"CommonPhraseCount.txt");
            string newChoice = string.Join("", choice.ToArray());
            for (int i = 0; i < phrases.Count; i++)
            {
                if (newChoice == phraseCommonalities[i].getWord())
                    phraseCommonalities[i].setCount(1 + phraseCommonalities[i].getCount());

                string pair = phraseCommonalities[i].ToString();
                phraseOut.WriteLine(pair);
            }
            phraseOut.Close();

        }

        public void storeWords()
        {
            StreamWriter wordOut = new StreamWriter(@"CommonWordCount.txt");
            string newChoice = string.Join("", choice.ToArray());
            for (int i = 0; i < words.Count; i++) {
                if (newChoice == wordCommonalities[i].getWord())
                    wordCommonalities[i].setCount(1+wordCommonalities[i].getCount());

                string pair = wordCommonalities[i].ToString();
                wordOut.WriteLine(pair);
            }
            wordOut.Close();
            
            
        }
        public void selectNewPhrase()
        {
            int index = myRand.Next(phrases.Count);
            for(int i = 0; i < phrases[index].Length; i++)
            {
                choice.Add(phrases[index][i]);
            }
        }
        public void CreateBrain()
        {
            for (int i = 0; i < choice.Count; i++)
            {
                switch (choice[i]) {
                    case '-':
                        Brain.Add('-');
                        break;
                    case '\'':
                        Brain.Add('\'');
                        break;
                    case '&':
                        Brain.Add('&');
                        break;
                    case '.':
                        Brain.Add('.');
                        break;
                    case ' ':
                        Brain.Add(' ');
                        break;
                    default:
                        Brain.Add(null);
                        break;
                }
            }
        }
        public void dunceMachineSolver()//dumbest machine
        {
            if (currLetter <= 'z' && Brain.Contains(null)) { 
                for (int i = 0; i < choice.Count; i++)
                {
                    if (choice[i] == currLetter)
                    {
                        numberFound++;
                        Brain[i] = currLetter;
                        wordListView.Items[i].Text = ""+currLetter;
                        wordListView.Refresh();                   
                    }
                } 
            }
            
            alphabet.Remove(currLetter);
            statusLabel.Text = "Dunce Machine Guessed: " + currLetter;
            statusLabel.Refresh();
            currLetter++;
            System.Threading.Thread.Sleep(1000);
            

            if (checkFinished())
            {
                result = "Dunce Machine Wins!";
                string labelString = string.Join("", choice.ToArray());
                endScreen end = new endScreen(result, labelString);
                storeWords();
                storePhrases();
                end.ShowDialog();
            }
            
            
        }
        public void okayMachineSolver()//2nd iter
        {
            char okayLetter = currLetter;
            while (!alphabet.Contains(okayLetter))
            {
                okayLetter++;
            }
            
            if (okayLetter <= 'z' && Brain.Contains(null))
            {
                for (int i = 0; i < choice.Count; i++)
                {
                    if (choice[i] == okayLetter)
                    {
                        numberFound++;
                        Brain[i] = okayLetter;
                        wordListView.Items[i].Text = "" + okayLetter;
                        wordListView.Refresh();
                    }
                }
            }

            if (alphabet.Contains(okayLetter))
            {
                alphabet.Remove(okayLetter);
                statusLabel.Text = "Okay Machine Guessed: " + okayLetter;
                statusLabel.Refresh();
                System.Threading.Thread.Sleep(2000);
            }
            if (checkFinished())
            {
                result = "Not so dumb machine Wins!";
                endScreen end = new endScreen(result, choice.ToString());
                storeWords();
                storePhrases();
                end.ShowDialog();
            }

        }
        public void guesserMachineSolver()//3rd iter
        {
            char guesserLetter = currLetter;
            if (!shouldIGuess(numberFound))
            {
                while (!alphabet.Contains(guesserLetter))
                {
                    guesserLetter++;
                }

                if (guesserLetter <= 'z' && Brain.Contains(null))
                {
                    for (int i = 0; i < choice.Count; i++)
                    {
                        if (choice[i] == guesserLetter)
                        {
                            numberFound++;
                            Brain[i] = guesserLetter;
                            wordListView.Items[i].Text = "" + guesserLetter;
                            wordListView.Refresh();
                        }
                    }
                }

                if (alphabet.Contains(guesserLetter))
                {
                    alphabet.Remove(guesserLetter);
                    statusLabel.Text = "Guesser Machine Guessed: " + guesserLetter;
                    statusLabel.Refresh();
                    System.Threading.Thread.Sleep(2000);
                }
                if (checkFinished())
                {
                    result = "The guesser machine Wins!";
                    string labelString = string.Join("", choice.ToArray());
                    endScreen end = new endScreen(result, labelString);
                    storeWords();
                    storePhrases();
                    end.ShowDialog();
                }
            }
            else
            {
                string name = "guesser";
                guessThePhrase(name);
            }
        }
        public void educatedMachineSolver()
        {
            List<String> applicablePhrases = new List<String>();
            for (int i = 0; i < phrases.Count(); i++)
            {
                if (phrases[i].Length == choice.Count() && !phrasesTried.Contains(phrases[i]))
                {
                    applicablePhrases.Add(phrases[i]);
                }
            }
            int howMany = applicablePhrases.Count();

            if (howMany == 1)
            {
                if (choice.Equals(applicablePhrases[0]))
                {
                    result = "Educated Wins!";
                    endScreen end = new endScreen(result, applicablePhrases[0]);
                    storeWords();
                    storePhrases();
                    end.ShowDialog();
                }
            }
            else
            {
                int countIn;
                int countOut;
                char bestLet = '!';
                double bestScore = 0;
                double lastPin = 0;
                double lastPout = 0;
                foreach (char let in alphabet)
                {
                    countIn = 0;
                    countOut = 0;
                    foreach (string phrase in applicablePhrases)
                    {
                        if (phrase.Contains(let))
                        {
                            countIn++;
                        }
                        else
                        {
                            countOut++;
                        }
                    }
                    double pIn = (double)countIn / howMany;
                    double pOut = (double)countOut / howMany;
                    double score = (pIn * Math.Log(pIn, 2)) - (pOut * Math.Log(pOut, 2));
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestLet = let;
                        lastPin = countIn;
                        lastPout = countOut;
                    }
                }
                for (int i = 0; i < choice.Count; i++)
                {
                    if (choice[i] == bestLet)
                    {
                        numberFound++;
                        Brain[i] = bestLet;
                        wordListView.Items[i].Text = "" + bestLet;
                        wordListView.Refresh();
                    }
                }
                if (alphabet.Contains(bestLet))
                {
                    alphabet.Remove(bestLet);
                    statusLabel.Text = "Educated Machine Guessed: " + bestLet;
                    statusLabel.Refresh();
                    System.Threading.Thread.Sleep(2000);
                }
                if (checkFinished())
                {
                    result = "The educated machine Wins!";
                    endScreen end = new endScreen(result, choice.ToString());
                    storeWords();
                    storePhrases();
                    end.ShowDialog();
                }
            }

        }

        public void humanSolver(char letterChoice)
        {
            statusLabel.Text = "Your Turn";
            statusLabel.Refresh();
            if (alphabet.Contains(letterChoice))
                alphabet.Remove(letterChoice);

            if (letterChoice <= 'z' && Brain.Contains(null))
            {
                for (int i = 0; i < choice.Count; i++)
                {
                    if (choice[i] == letterChoice)
                    {
                        numberFound++;
                        Brain[i] = letterChoice;
                        wordListView.Items[i].Text = "" + letterChoice;
                        wordListView.Refresh();
                    }
                }
            }

            if (checkFinished())
            {
                result = "You Win!";
                endScreen end = new endScreen(result, choice.ToString());
                storeWords();
                storePhrases();
                end.ShowDialog();             
            }
            else
            {
                while (!checkFinished())
                {
                    educatedMachineSolver();
                }
                //dunceMachineSolver();
                //okayMachineSolver();
                //guesserMachineSolver();
                //educatedMachineSolver();
                //statusLabel.Text = "Your Turn";
                //statusLabel.Refresh();
            }
            

        }

        private void Board_Load(object sender, EventArgs e)
        {
            wordListView.Items.Clear();
            foreach (char elem in choice)
            {
                switch (elem)
                {
                    case '-':
                        wordListView.Items.Add(new ListViewItem("-"));
                        break;
                    case '\'':
                        wordListView.Items.Add(new ListViewItem("\'"));
                        break;
                    case '&':
                        wordListView.Items.Add(new ListViewItem("&"));
                        break;
                    case '.':
                        wordListView.Items.Add(new ListViewItem("."));
                        break;
                    case ' ':
                        wordListView.Items.Add(new ListViewItem(" "));
                        break;
                    default:
                        wordListView.Items.Add(new ListViewItem("#"));
                        break;
                }
                
            }
            
        }

        private void guessButton_Click(object sender, EventArgs e)
        {
            foreach (Control item in letters.panel1.Controls)
            {
                if (!alphabet.Contains(item.Name[0]))
                    letters.panel1.Controls.Remove(item);
            }
            letters.ShowDialog();

            char letterChoice = letters.chosenLetter;
            humanSolver(letterChoice);
            
        }
        public bool checkFinished()
        {
            if (!Brain.Contains(null))
            {
                return true;
            }
            return false;
        }

        private void takeAGuessButton_Click(object sender, EventArgs e)
        {
            GuessPage guessPage = new GuessPage();
            guessPage.ShowDialog();
            string phraseGuessed = guessPage.phrase;
            if (checkGuess(phraseGuessed))
            {
                result = "You Win!";
                endScreen end = new endScreen(result, phraseGuessed);
                storeWords();
                storePhrases();
                end.ShowDialog();
            }
            else
            {
                dunceMachineSolver();
                okayMachineSolver();
                guesserMachineSolver();
                statusLabel.Text = "Your Turn";
                statusLabel.Refresh();
            }
        }

        public bool checkGuess(string phraseGuessed)
        {
            if (phraseGuessed.Length != choice.Count)
            {
                return false;
            }
            for (int i = 0; i < choice.Count; i++)
            {
                if (phraseGuessed[i] != choice[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool shouldIGuess(int num)
        {
            float probability = 0;
            probability = (float)num / choice.Count;

            if (probability >= .8)
            {
                return true;
            }
            return false;
        }

        public void guessThePhrase(string sender)
        {
            string phraseToTry = "";
            for (int i = 0; i < phraseCommonalities.Count; i++)
            {
                if (Brain.Count == phraseCommonalities[i].word.Length && !phrasesTried.Contains(phraseCommonalities[i].word))
                {
                    string phrase = phraseCommonalities[i].word;
                    for (int j = 0; j < Brain.Count; j++)
                    {
                        char currChar = '?';
                        if (Brain[j] != null)
                        {
                            currChar = Convert.ToChar(Brain[j]);
                        }
                        if (currChar != phrase[j] && currChar != '?')
                        {
                            j = Brain.Count;//try the next phrase
                        }
                        else if (j == Brain.Count - 1)
                        {
                            phraseToTry = phrase;
                            phrasesTried.Add(phrase);
                            i = phraseCommonalities.Count;
                        }
                        
                    }
                }
                
            }
            if (checkGuess(phraseToTry))
            {
                result = sender + " Wins!";
                endScreen end = new endScreen(result, phraseToTry);
                storeWords();
                storePhrases();
                end.ShowDialog();
            }
            else
            {
                statusLabel.Text = "Your Turn";
                statusLabel.Refresh();
            }
        }


    }


    public class CommonCount
    {
        public string word;

        public string getWord()
        {
            return this.word;
        }
        public void setWord(string w)
        {
            this.word = w;
        }
        public int count;

        public int getCount()
        {
            return this.count;
        }
        public void setCount(int c)
        {
            this.count = c;
        }

        public CommonCount(string w, int c)
        {
            word = w;
            count = c;
        }
        public override string ToString()
        {
            return String.Concat(this.count, " ", this.word);
        }
    }
}
