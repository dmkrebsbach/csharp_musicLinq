using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist mountVern = Artists.FirstOrDefault(artist => artist.Hometown == "Mount Vernon");
            Console.WriteLine("The Artist from Mount Vernon is :");
            Console.WriteLine(mountVern.RealName);
            Console.WriteLine();

            //Who is the youngest artist in our collection of artists?
            int age = Artists.Min(artist => artist.Age);
            Artist youngest = Artists.FirstOrDefault(artist => artist.Age == age);
            Console.WriteLine("The youngest Artist in the Group is :");
            Console.WriteLine(youngest.ArtistName + ", " + youngest.Age + " years old");
            Console.WriteLine();

            //Display all artists with 'William' somewhere in their real name
            List<Artist> wills = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            wills.ForEach(i => Console.WriteLine("{0}\t", i.RealName + " aka " + i.ArtistName));
            Console.WriteLine();
            
            //Display the 3 oldest artist from Atlanta
            List<Artist> hotlanta = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(artist => artist.Age).Take(3).ToList();
            hotlanta.ForEach(i => Console.WriteLine("{0}\t", i.RealName + " aka " + i.ArtistName + ", " + i.Age + " years old"));
            Console.WriteLine();

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            IEnumerable <string> notNyc = Artists.Where(artist => artist.Hometown != "New York City").Join(Groups, 
                artId => artId.GroupId, 
                grpId => grpId.Id, 
                (artId, grpId) => 
                {
                    return artId.ArtistName + ", " + grpId.GroupName;
                });
                Console.WriteLine(notNyc);
                
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            
        }
    }
}
