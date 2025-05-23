using OpenUtau.Api;
using OpenUtau.Core.G2p;

namespace OpenUtau.Core.DiffSinger
{
    [Phonemizer("DiffSinger English Phonemizer", "DIFFS EN", language: "EN")]
    public class DiffSingerEnglishPhonemizer : DiffSingerG2pPhonemizer
        {
        protected override string GetDictionaryName() => "dsdict-en.yaml";
        protected override string GetLangCode() => "en";
        protected override IG2p LoadBaseG2p() => new ArpabetG2p();
        protected override string[] GetBaseG2pVowels() => new string[] {
            "aa", "ae", "ah", "ao", "aw", "ay", "eh", "er",
            "ey", "ih", "iy", "ow", "oy", "uh", "uw"
        };

        protected override string[] GetBaseG2pConsonants() => new string[] {
            "b", "ch", "d", "dh", "f", "g", "hh", "jh", "k", "l", "m", "n",
            "ng", "p", "r", "s", "sh", "t", "th", "v", "w", "y", "z", "zh"
        };

        protected override string[] GetSymbols(Note note) {
            if (!string.IsNullOrEmpty(note.phoneticHint)) {
                return ParsePhoneticHint(note.phoneticHint);
            }
            var g2presult = g2p.Query(note.lyric)
                ?? g2p.Query(note.lyric.ToLowerInvariant());
            if (g2presult != null) {
                if (note.lyric != "SP" && note.lyric != "AP") {
                    g2presult = g2p.Query(note.lyric.ToLowerInvariant());
                    return g2presult;
                }
                return g2presult;
            }
            var lyricSplited = ParsePhoneticHint(note.lyric);
            if (lyricSplited.Length > 0) {
                return lyricSplited;
            }
            return new string[] { };
        }
    }
}