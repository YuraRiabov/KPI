using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._1__Cs
{
    public class Program
    {
        static void Main()
        {
            IOManager iOManager = new IOManager();
            FileManager fileManager = new FileManager();

            const string initialFileName = "initialFile.txt";
            const string secondFileName = "secondFile.txt";

            iOManager.InformUser();
            bool append = iOManager.AskAppending();
            List<string> text = iOManager.GetText();
            fileManager.WriteToFile(initialFileName, text, append);
            int lastLinesNumber = iOManager.AskLastLinesNumber();
            append = iOManager.AskAppending();
            List<string> textToTransfer = fileManager.GetFileContent(initialFileName, lastLinesNumber);
            fileManager.WriteToFile(secondFileName, textToTransfer, append);
            int removed = fileManager.RemoveRepeatingLines(secondFileName);
            iOManager.OutputText(fileManager.GetFileContent(secondFileName));
            iOManager.OutputLinesRemoved(removed);
        }
    }
//Keep you in the dark
//You know they all pretend
//Keep you in the dark
//And so it all began
//Send in your skeletons
//Sing as their bones go marching in again
//They need you buried deep
//The secrets that you keep are ever ready
//Are you ready?
//I'm finished making sense
//Done pleading ignorance
//That old defense
//Spinning infinity, boy
//The wheel is spinning me
//It's never-ending, never-ending
//Same old story
//What if I say I'm not like the others?
//What if I say I'm not just another one of your plays?
//You're the pretender
//What if I say I will never surrender?
//What if I say I'm not like the others?
//What if I say I'm not just another one of your plays?
//You're the pretender
//What if I say that I never surrender?
//In time, or so I'm told,
//I'm just another soul for sale, oh well
//The page is out of print
//We are not permanent
//We're temporary, temporary
//Same old story
//What if I say I'm not like the others?
//What if I say I'm not just another one of your plays?
//You're the pretender
//What if I say I will never surrender?
//What if I say I'm not like the others?
//What if I say I'm not just another one of your plays?
//You're the pretender
//What if I say I will never surrender?
//I'm the voice inside your head you refuse to hear
//I'm the face that you have to face mirrorin' your stare
//I'm what's left; I'm what's right; I'm the enemy
//I'm the hand that'll take you down and bring you to your knees
//So, who are you?
//Yeah, who are you?
//Yeah, who are you?
//Yeah, who are you?
//Keep you in the dark
//You know they all pretend
//What if I say I'm not like the others?
//What if I say I'm not just another one of your plays?
//You're the pretender
//What if I say I will never surrender?
//What if I say I'm not like the others?
//What if I say I'm not just another one of your plays?
//You're the pretender
//What if I say that I'll never surrender?
//What if I say I'm not like the others?
//(Keep you in the dark)
//What if I say I'm not just another one of your plays?
//(You know they all)
//You're the pretender
//(Pretend)
//What if I say I will never surrender?
//What if I say I'm not like the others?
//(Keep you in the dark)
//What if I say I'm not just another one of your plays?
//(You know they all)
//You're the pretender
//(Pretend)
//What if I say I will never surrender?
//So, who are you?
//Yeah, who are you?
//Yeah, who are you?
}