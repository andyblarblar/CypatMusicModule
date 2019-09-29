
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
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
                                  "2) list available sounds\n" +
                                  "3) play songs\n" +
                                  "~) Custom sounds guidelines\n" +
                                  "Q) quit\n");
                var UI = "";

                UI = Console.ReadLine();

                switch (UI)
                {

                    case "1":
                        CypatReplace();
                        break;

                    case "2":
                        ListCustomFiles();
                        break;

                    case "3":
                        PlaySongs();
                        break;

                    case "~":
                        Console.WriteLine(
                            "\n\n\nto use your oun files you must: \n1) you MUST have a file in a proper .wav format\n2) place this file in \"musicFiles\" \n3) be sure to enter \".wav\" when you enter its name\n",
                            Color.HotPink);
                        break;

                    case "Q":
                        return true;

                    default:
                        Console.WriteLine("Bad input");
                        break;

                }

                return false;
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
        if (!Directory.Exists(@"/opt/CyberPatriot"))
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
                    Console.WriteLine("Failed to write file", Color.Crimson);
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

        return;

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
                    Console.WriteLine("Failed to write file", Color.Crimson);
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


    static void WriteSoundFile(bool isGain, bool isLinux, string fileName)
    {
        if (isLinux)
        {
            var file2 = File.ReadAllBytes("musicFiles/" + fileName);


            if (isGain)
            {
                File.WriteAllBytes(@"/opt/CyberPatriot/gain.wav", file2);
                return;
            }

            else
            {
                File.WriteAllBytes(@"/opt/CyberPatriot/alarm.wav", file2);
                File.WriteAllBytes(@"/opt/CyberPatriot/siren.wav", file2);
            }

            return;
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



    /// <summary>
    /// Read contents of an embedded resource file as bytes
    /// </summary>
    /// <param name="filename">just the files name ex. file.txt</param>
    public static byte[] ReadResourceFileAsBytes(string filename)
    {
    var thisAssembly = Assembly.GetExecutingAssembly();
        using (var stream = thisAssembly.GetManifestResourceStream(thisAssembly.GetManifestResourceNames()
    .Single(str => str.EndsWith(filename))))
    {
        if (stream == null) return null;
        byte[] ba = new byte[stream.Length];
        stream.Read(ba, 0, ba.Length);
        return ba;

    }
    }


        public static void ListCustomFiles()
    {

    var files = Directory.GetFiles("musicFiles");
        foreach (var file in files)
    {
        Console.WriteLine(file.Split("\\")[1]);

    }
        Console.WriteLine();
    }


        public static void PlaySongs()
        {
            var isLinux = Environment.OSVersion.Platform == PlatformID.Unix;

            if (isLinux)
            {
                var input = string.Empty;
                Console.WriteLine("select a song to play:\n" +
                                  "C) custom file\n");
                input = Console.ReadLine();
                var filepath = string.Empty;

                switch (input)
                {

                    case "C":
                        Console.WriteLine("please enter the file path"); 
                        filepath = Console.ReadLine(); 
                        break;

                    default:
                        Console.WriteLine("Bad input, exiting...");
                        return;

                }

                var soxOptions = new ProcessStartInfo("play", $"\'filepath\'")
                {
                    CreateNoWindow = true
                };

                Process sox = Process.Start(soxOptions);
                sox.Exited += (sender, args) => sox.Dispose(); 
                return;

            }


            var input2 = string.Empty;
            Console.WriteLine("select a song to play:\n" +
                              "C) custom file\n");
            input2 = Console.ReadLine();
            var filepath2 = string.Empty;

            switch (input2)
            {

                case "C":
                    Console.WriteLine("please enter the file path");
                    filepath2 = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Bad input, exiting...");
                    return;

            }

            var ffplayOptions = new ProcessStartInfo(".\\ffplay.exe", $"-nodisp \"{filepath2}\"")
            {
                CreateNoWindow = true,
            };

            Process ffplay = Process.Start(ffplayOptions);
            
            ffplay.Exited += (sender, args) => ffplay.Dispose();
            return;
        }

}

}

