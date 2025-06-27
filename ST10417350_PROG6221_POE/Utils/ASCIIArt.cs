using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10417350_PROG6221_POE.Utils
{
    internal class ASCIIArt
    {
        /// <summary>
        /// Returns the ASCII art banner for the application.
        /// </summary>
        public static string GetBanner()
        {
            return @"
               .          *    .         .        *       .        .   *
      *    .    .        .     .     *        .         .      *        . 
  .         *         .      .     .     .    .     *       .       .      * 

                        ___________________________
                       |   ________________________   |        *
                       |  |                                                |  |
                       |  |              Welcome                   |  |     . 
                       |  |          Stay Safe Online            |  |
                       |  |________________________|  |
                       |___________________________|
                                   ||                               ||
                                   ||       ________        ||            *
                                   ||      |                |        ||
                                   ||      |________|        ||     . 
                                   ||________________||
                               /____________________\
                             [_______________________]
                                   \__/                     \__/

  *     .         .       .        *         .         .       .       *     .
                            CYBERSECURITY AWARENESS BOT
       *       .      *         .      .        *        .         *         .";
        }
    }
}