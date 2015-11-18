using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WheelOfFortune
{
    public partial class Board : Form
    {
        public List<String> words = new List<String>();
        public Random myRand = new Random();
        public List<char> choice = new List<char>();
        public ArrayList Brain = new ArrayList();
        public List<char> chosenLetters = new List<char>();
        public char currLetter = 'a';
        public string result;
        private Dictionary<int, CommonCount> commonalities = new Dictionary<int, CommonCount>();

        

        public Board()
        {
            InitializeComponent();
            getWords();
            selectNewWord();
            CreateBrain();            
        }
        public void getWords()
        {
            string line;
            int counter = 0;
            System.IO.StreamReader filein =
            new System.IO.StreamReader(@"dictionary.txt");
            while ((line = filein.ReadLine()) != null)
            {
                CommonCount pair = new CommonCount(line, 0);
                commonalities.Add(counter, pair);
                words.Add(line);
                counter++;
            }
            words.Sort();
            filein.Close();
        }
        public void storeWords()
        {
            System.IO.StreamWriter fileout = new StreamWriter(@"CommonWordCount.txt");
            string newChoice = string.Join("", choice.ToArray());
            for (int i = 0; i < words.Count; i++) {
                if (newChoice == commonalities[i].getWord())
                    commonalities[i].setCount(1+commonalities[i].getCount());

                string pair = commonalities[i].ToString();
                fileout.WriteLine(""+i+" "+pair);
            }
            fileout.Close();
            
        }
        public void selectNewWord()
        {
            int index = myRand.Next(words.Count);
            for(int i = 0; i < words[index].Length; i++)
            {
                choice.Add(words[index][i]);
            }
        }
        public void CreateBrain()
        {
            for (int i = 0; i < choice.Count; i++)
            {
                Brain.Add(null);
            }
        }
        public void dunceMachineSolver()//dumbest machine
        {
            if (!chosenLetters.Contains(currLetter))
                chosenLetters.Add(currLetter);

            if (currLetter <= 'z' && Brain.Contains(null)) { 
                for (int i = 0; i < choice.Count; i++)
                {
                    if (choice[i] == currLetter)
                    {
                        Brain[i] = currLetter;
                        wordListView.Items[i].Text = ""+currLetter;
                        wordListView.Refresh();                   
                    }
                }
                currLetter++;
            }

            if (!Brain.Contains(null))
            {
                result = "Dunce Machine Wins!";
                endScreen end = new endScreen(result);
                storeWords();
                end.ShowDialog();
            }
            
        }
        public void okayMachineSolver()//2nd iter
        {
            char okayLetter = currLetter;
            while (chosenLetters.Contains(okayLetter))
            {
                okayLetter++;
            }
            if (okayLetter <= 'z' && Brain.Contains(null))
            {
                for (int i = 0; i < choice.Count; i++)
                {
                    if (choice[i] == okayLetter)
                    {
                        Brain[i] = okayLetter;
                        wordListView.Items[i].Text = "" + okayLetter;
                        wordListView.Refresh();
                    }
                }
            }

            chosenLetters.Add(okayLetter);
            if (!Brain.Contains(null))
            {
                result = "Not so dumb machine Wins!";
                endScreen end = new endScreen(result);
                storeWords();
                end.ShowDialog();
            }

        }
        public void humanSolver(char letterChoice)
        {
            if (!chosenLetters.Contains(letterChoice))
                chosenLetters.Add(letterChoice);

            if (letterChoice <= 'z' && Brain.Contains(null))
            {
                for (int i = 0; i < choice.Count; i++)
                {
                    if (choice[i] == letterChoice)
                    {
                        Brain[i] = letterChoice;
                        wordListView.Items[i].Text = "" + letterChoice;
                        wordListView.Refresh();
                    }
                }
            }

            if (!Brain.Contains(null))
            {
                result = "You Win!";
                endScreen end = new endScreen(result);
                storeWords();
                end.ShowDialog();             
            }

        }

        private void Board_Load(object sender, EventArgs e)
        {
            wordListView.Items.Clear();
            foreach (char elem in choice)
            {
                wordListView.Items.Add(new ListViewItem("#"));
            }
        }

        private void guessButton_Click(object sender, EventArgs e)
        {
            keyboard letters = new keyboard();
            letters.ShowDialog();

            char letterChoice = letters.chosenLetter;
            humanSolver(letterChoice);
            dunceMachineSolver();
            okayMachineSolver();
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
