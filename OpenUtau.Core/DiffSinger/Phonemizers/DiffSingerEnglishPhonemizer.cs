using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using OpenUtau.Api;
using OpenUtau.Core.G2p;
using OpenUtau.Core.Ustx;

using Serilog;

using SharpCompress.Common;

using static OpenUtau.Api.G2pDictionary;
using static OpenUtau.Api.G2pDictionaryData;

namespace OpenUtau.Core.DiffSinger {
    [Phonemizer("DiffSinger English Phonemizer", "DIFFS EN", language: "EN")]
    public class DiffSingerEnglishPhonemizer : DiffSingerG2pPhonemizer {
        USinger singer;
        protected override string GetDictionaryName() => "dsdict-en.yaml";
        protected override string GetLangCode() => "en";
        protected override IG2p LoadBaseG2p() {

            parseUpperAsLower = false;

            return new ArpabetG2p();
        }

        protected override string[] GetBaseG2pVowels() => new string[] {
            "aa", "ae", "ah", "ao", "aw", "ay", "eh", "er",
            "ey", "ih", "iy", "ow", "oy", "uh", "uw"
        };

        protected override string[] GetBaseG2pConsonants() => new string[] {
            "b", "ch", "d", "dh", "f", "g", "hh", "jh", "k", "l", "m", "n",
            "ng", "p", "r", "s", "sh", "t", "th", "v", "w", "y", "z", "zh"
        };

        protected override string[] GetSymbols(Note note) {
            parseUpperAsLower = true;
            return base.GetSymbols(note);
        }
    }
}