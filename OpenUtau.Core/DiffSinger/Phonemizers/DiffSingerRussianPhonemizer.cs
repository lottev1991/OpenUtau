using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

using OpenUtau.Api;
using OpenUtau.Core.G2p;
using OpenUtau.Core.Voicevox;

namespace OpenUtau.Core.DiffSinger
{
    [Phonemizer("DiffSinger Russian Phonemizer", "DIFFS RU", language: "RU")]
    public class DiffSingerRussianPhonemizer : DiffSingerG2pPhonemizer
    {
        protected override string GetDictionaryName()=>"dsdict-ru.yaml";
        public override string GetLangCode()=>"ru";
        protected override IG2p LoadBaseG2p() => new RussianG2p();
        protected override string[] GetBaseG2pVowels() => new string[] {
            "a", "aa", "ay", "ee", "i", "ii", "ja", "je", "jo", "ju", "oo",
            "u", "uj", "uu", "y", "yy"
        };

        protected override string[] GetBaseG2pConsonants() => new string[] {
            "b", "bb", "c", "ch", "d", "dd", "f", "ff", "g", "gg", "h", "hh",
            "j", "k", "kk", "l", "ll", "m", "mm", "n", "nn", "p", "pp", "r", 
            "rr", "s", "sch", "sh", "ss", "t", "tt", "v", "vv", "z", "zh", "zz"
        };

        protected string[] HardConsonants() => new string[] {
           "b", "v", "g", "d", "zh", "z", "k", "l", "m", "n", "p", "r", "s",
           "t", "f", "h", "c", "sh"
        };

        //public override Result Process(Note[] notes, Note? prev, Note? next, Note? prevNeighbour, Note? nextNeighbour, Note[] prevs) {
        //    var processedPhonemes = new List<Phoneme>();
        //    var langCode = GetLangCode() + "/";

        //    if (!partResult.TryGetValue(notes[0].position, out var phonemes)) {
        //        throw new Exception("Result not found in the part");
        //    }

        //    for (int i = 0; i < phonemes.Count; i++) {
        //        var tu = phonemes[i];
        //        //var nextTu = phonemes[i + 1];
        //        if (i < phonemes.Count - 1) {
        //            foreach (var hc in HardConsonants()) {
        //                //if (phonemes[i + 1] != null) {
        //                    if (tu.Item1 == langCode + hc) {
        //                        if (phonemes[i + 1].Item1 == langCode + "i") {
        //                            processedPhonemes.Add(new Phoneme() {
        //                                phoneme = tu.Item1,
        //                                position = tu.Item2
        //                            });
        //                            processedPhonemes.Add(new Phoneme() {
        //                                phoneme = langCode + "y",
        //                                position = phonemes[i + 1].Item2
        //                            });
        //                            i++;
        //                        } else if (phonemes[i + 1].Item1 == langCode + "ii") {
        //                            processedPhonemes.Add(new Phoneme() {
        //                                phoneme = tu.Item1,
        //                                position = tu.Item2
        //                            });
        //                            processedPhonemes.Add(new Phoneme() {
        //                                phoneme = langCode + "yy",
        //                                position = phonemes[i + 1].Item2
        //                            });
        //                            i++;
        //                        } else {
        //                            processedPhonemes.Add(new Phoneme() {
        //                                phoneme = tu.Item1,
        //                                position = tu.Item2
        //                            });
        //                            i++;
        //                            //processedPhonemes.Add(new Phoneme() {
        //                            //    phoneme = phonemes[i + 1].Item1,
        //                            //    position = phonemes[i + 1].Item2
        //                            //});
        //                            //i++;
        //                        }
        //                    } else if (tu.Item1 == hc) {
        //                        if (phonemes[i + 1].Item1 == "i") {
        //                            processedPhonemes.Add(new Phoneme() {
        //                                phoneme = tu.Item1,
        //                                position = tu.Item2
        //                            });
        //                            processedPhonemes.Add(new Phoneme() {
        //                                phoneme = "y",
        //                                position = phonemes[i + 1].Item2
        //                            });
        //                            i++;
        //                        } else if (phonemes[i + 1].Item1 == "ii") {
        //                            processedPhonemes.Add(new Phoneme() {
        //                                phoneme = tu.Item1,
        //                                position = tu.Item2
        //                            });
        //                            processedPhonemes.Add(new Phoneme() {
        //                                phoneme = "yy",
        //                                position = phonemes[i + 1].Item2
        //                            });
        //                            i++;
        //                        } else {
        //                            processedPhonemes.Add(new Phoneme() {
        //                                phoneme = tu.Item1,
        //                                position = tu.Item2
        //                            });
        //                            i++;
        //                        //processedPhonemes.Add(new Phoneme() {
        //                        //    phoneme = phonemes[i + 1].Item1,
        //                        //    position = phonemes[i + 1].Item2
        //                        //});
        //                        //i++;
        //                        }
        //                    } else {
        //                        processedPhonemes.Add(new Phoneme() {
        //                            phoneme = tu.Item1,
        //                            position = tu.Item2
        //                        });
        //                        i++;
        //                    }
        //                //} else {
        //                //    processedPhonemes.Add(new Phoneme() {
        //                //        phoneme = tu.Item1,
        //                //        position = tu.Item2
        //                //    });
        //                //}
                        

        //                //if (tu.Item1 == langCode + hc && nextTu.Item1 == langCode + "i") {
        //                //    processedPhonemes.Add(new Phoneme() {
        //                //        phoneme = langCode + "y",
        //                //        position = nextTu.Item2
        //                //    });
        //                //    i++;
        //                //} else if (tu.Item1 == langCode + hc && nextTu.Item1 == langCode + "ii") {
        //                //    processedPhonemes.Add(new Phoneme() {
        //                //        phoneme = langCode + "yy",
        //                //        position = nextTu.Item2
        //                //    });
        //                //    i++;
        //                //} else if (tu.Item1 == hc && nextTu.Item1 == "i") {
        //                //    processedPhonemes.Add(new Phoneme() {
        //                //        phoneme = "y",
        //                //        position = nextTu.Item2
        //                //    });
        //                //    i++;
        //                //} else if (tu.Item1 == hc && nextTu.Item1 == "ii") {
        //                //    processedPhonemes.Add(new Phoneme() {
        //                //        phoneme = "yy",
        //                //        position = nextTu.Item2
        //                //    });
        //                //    i++;
        //                //}
        //            }


        //        }
        //    }
        //    return new Result {
        //        phonemes = processedPhonemes.ToArray()
        //    };
        //}
    }
}
