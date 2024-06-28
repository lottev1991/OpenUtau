using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML.OnnxRuntime;
using OpenUtau.Api;

namespace OpenUtau.Core.G2p {
    public class EcclesiasticalLatinG2p : G2pPack {
        private static readonly string[] graphemes = new string[] {
            "", "", "", "", "\u0306\u0306", "\u203f", "\u0306", "a", "ā", "æ",
            "b", "c", "d", "e", "ē", "ë", "ĕ", "f", "g",
            "h", "i", "ï", "ī", "ĭ", "j", "k", "l", "m",
            "n", "o", "ō", "ŏ", "p", "q", "r", "ꝶ", "s",
            "t", "u", "ū", "ũ", "ŭ", "v", "w", "x", "y",
            "ȳ", "z"
        };

        private static readonly string[] phonemes = new string[] {
            "", "", "", "", "a", "b", "d", "dz", "dZ", "e",
            "f", "g", "i", "i^", "j", "J", "k", "l", "m", "n",
            "o", "p", "r", "s", "S", "t", "ts", "tS", "u", "u^",
            "v", "w", "z"
        };

        private static object lockObj = new object();
        private static Dictionary<string, int> graphemeIndexes;
        private static IG2p dict;
        private static InferenceSession session;
        private static Dictionary<string, string[]> predCache = new Dictionary<string, string[]>();

        public EcclesiasticalLatinG2p() {
            lock (lockObj) {
                if (graphemeIndexes == null) {
                    graphemeIndexes = graphemes
                        .Skip(4)
                        .Select((g, i) => Tuple.Create(g, i))
                        .ToDictionary(t => t.Item1, t => t.Item2 + 4);
                    var tuple = LoadPack(Data.Resources.g2p_la_va);
                    dict = tuple.Item1;
                    session = tuple.Item2;
                }
            }
            GraphemeIndexes = graphemeIndexes;
            Phonemes = phonemes;
            Dict = dict;
            Session = session;
            PredCache = predCache;
        }
    }
}
