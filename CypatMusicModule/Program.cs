
using System;
using System.Drawing;
using System.IO;
using Console = Colorful.Console;

namespace CypatMusicModule
{

#nullable enable
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"                   
                        +It.             
                        +II+             
                        +III;            
                        +IIII;           
                        iIIIII;          
                        titIIII;         
                        I;.iIIII;        
                        .I;  =IIII;       
                        .I;   ;IIII:      
                        .I;    :tIIt      
                        .I;     .tII=     
                        .I;      :III     
                        :I;       +II;    
                        :I;       .II=    
                        :I:        iIi    
                        :I.        ;Ii    
                        ;I.        =I;    
                        ;I.        tt     
                        +I        ;I;     
                        +I       ;I;      
                        tI      ;I;       
                 :;itIIIII     +t:        
               ;tIIIIIIIII   :t;          
             .tIIIIIIIIIIi  ;i.           
            .tIIIIIIIIIII;.;:             
            ;IIIIIIIIIII;                 
             ;IIIIIIIIIt;                  
               ;tIIIIt+;                    
                 ...." + "\n");

            Console.WriteLine("Welcome To the CypatMusicModule!\n What would you like to do?");

            bool done = false;

            while (!done)
            {
             
               done = PrintOptions();

            }


        }


        public static bool PrintOptions()
        {
            while (true)
            {
                Console.WriteLine("1) replace Cypat sounds\n" +
                                  "~) Custom sounds guidelines\n" +
                                  "Q) quit\n");
                var UI = "";
                
                UI = Console.ReadLine();

                switch (UI)
                {
                    
                    case "1":
                        CypatReplace();
                        break;

                    case "~":
                        Console.WriteLine("\n\n\nto use your oun files you must: \n1) you MUST have a file in a proper .wav format\n2) place this file in \"musicFiles\" \n3) be sure to enter \".wav\" when you enter its name\n",Color.HotPink);
                        break;

                    case "Q":
                        return true;


                }

            }

        }

        /// <summary>
        ///  Prompts console with options to replace the default Cypat sounds with, and then replaces.
        /// </summary>
        public static void CypatReplace()
        {
            var isLinux = Environment.OSVersion.Platform == PlatformID.Unix;

            if (isLinux)
            {
                /* Linux track */

            }

            else
            {

                if (!Directory.Exists(@"C:\Cyberpatriot"))
                {
                    Console.WriteLine("You silly goose! This isnt a cypat VM!\n");
                    return;
                }

                Console.WriteLine("What do you want to replace the score gain sound with?\n" +
                                       "1) This is a good result!\n" +
                                       "2) noice\n" +
                                       "3) MC level up\n" +
                                       "C) custom\n" +
                                       "Literally anything else) dont change");
                var response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        WriteSoundFile(true, isLinux, "good-result.wav");
                        break;

                    case "2":
                        WriteSoundFile(true, isLinux, "nice.wav");
                        break;

                    case "3":
                        WriteSoundFile(true, isLinux, "levelup.wav");
                        break;

                    case "C":
                        Console.WriteLine("please enter the name of your file...");
                        var input = Console.ReadLine();
                        try
                        {
                            WriteSoundFile(true, isLinux, input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Failed to write file",Color.Crimson);
                        }
                        break;

                    default:
                        Console.WriteLine("alrighty");
                        break;
                }

                Console.WriteLine("And what about the score lose and siren sound?\n" +
                                      "1) OOF!\n" +
                                      "2) scott the woz (oh heck a swear)\n" +
                                      "3) 56k\n" +
                                      "4) nope\n" +
                                      "5) seinfeld\n" +
                                      "C) custom" +
                                      "anything else) dont change");

                response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        WriteSoundFile(false, isLinux, "roblox-death-sound_1.wav");
                        break;

                    case "2":
                        WriteSoundFile(false, isLinux, "scottDARNIT.wav");
                        break;

                    case "3":
                        WriteSoundFile(false, isLinux, "56k.wav");
                        break;

                    case "4":
                        WriteSoundFile(false, isLinux, "nope.wav");
                        break;
                        
                    case "5":
                        WriteSoundFile(false, isLinux, "seinfeld.wav");
                        break;

                    case "C":
                        Console.WriteLine("please enter the name of your file...");
                        var input = Console.ReadLine();
                        try
                        {
                            WriteSoundFile(false, isLinux, input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Failed to write file", Color.Crimson);
                        }
                        break;

                }


            }

            
            static void WriteSoundFile(bool isGain, bool isLinux, string fileName)//TODO linux
            {
                if (isLinux)
                {
                    //linux stuff

                }

                var file = File.ReadAllBytes("musicFiles\\" + fileName); //windows stuff

                if (isGain)
                {
                    File.WriteAllBytes(@"C:\CyberPatriot\gain.wav", file);
                    return;
                }

                else
                {
                    File.WriteAllBytes(@"C:\CyberPatriot\alarm.wav", file);
                    File.WriteAllBytes(@"C:\CyberPatriot\siren.wav", file);
                }


            }
        }
    }
}
