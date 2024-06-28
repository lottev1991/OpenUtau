using OpenUtau.Api;
using OpenUtau.Core.G2p;

namespace OpenUtau.Core.DiffSinger {
    /// <summary>
    /// Classical Latin phonemizer for DiffSinger voicebanks.
    /// <br></br>
    /// More information on Classical Latin phonology can be found <a href="https://en.wikipedia.org/wiki/Latin_phonology_and_orthography#Letters_and_phonemes">here</a>.
    /// </summary>
    [Phonemizer("DiffSinger Classical Latin Phonemizer", "DIFFS LA-CLA", "Lotte V", language: "LA-CLA")]
    public class DiffSingerClassicalLatinPhonemizer : DiffSingerG2pPhonemizer {
        protected override string GetDictionaryName() => "dsdict-la-cla.yaml";
        protected override IG2p LoadBaseG2p() => new ClassicalLatinG2p();
        protected override string[] GetBaseG2pVowels() => new string[]{
            "a", "a:", "e", "e:", "i", "i:", "o", "o:", "u", "u:", "y", "y:"
        };
        protected override string[] GetBaseG2pConsonants() => new string[] {
            "b", "d", "e^", "f", "g", "gw", "h", "i^", "k", "kh", "kw", "l",
            "m", "n", "p", "ph", "r", "s", "t", "th", "tS", "u^", "v", "z"
        };
    }
}
