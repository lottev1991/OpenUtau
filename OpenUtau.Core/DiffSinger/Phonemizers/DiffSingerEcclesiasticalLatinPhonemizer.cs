using OpenUtau.Api;
using OpenUtau.Core.G2p;

namespace OpenUtau.Core.DiffSinger {
    /// <summary>
    /// Ecclesiastical (Church) Latin phonemizer for DiffSinger voicebanks.
    /// <br></br>
    /// More information on Ecclesiastical Latin phonology can be found <a href="https://en.wikipedia.org/wiki/Latin_phonology_and_orthography#Ecclesiastical_pronunciation">here</a>.
    /// </summary>
    [Phonemizer("DiffSinger Church Latin Phonemizer", "DIFFS LA-VA", "Lotte V", language: "LA-VA")]
    public class DiffSingerEcclesiasticalLatinPhonemizer : DiffSingerG2pPhonemizer {
        protected override string GetDictionaryName() => "dsdict-la-va.yaml";
        protected override IG2p LoadBaseG2p() => new EcclesiasticalLatinG2p();
        protected override string[] GetBaseG2pVowels() => new string[]{
            "a", "e", "i", "o", "u"
        };
        protected override string[] GetBaseG2pConsonants() => new string[] {
            "b", "d", "dz", "dZ", "f", "g", "i^", "j", "J", "k", "l", "m",
            "n", "p", "r", "s", "S", "t", "ts", "tS", "u^", "v", "w", "z"
        };
    }
}
