using System.Collections.Generic;
using System.Linq;
using OpenUtau.Api;
using Pinyin;

namespace OpenUtau.Core.DiffSinger {
    [Phonemizer("DiffSinger Hokkien Phonemizer", "DIFFS NAN", language: "NAN")]
    public class DiffSingerHokkienPhonemizer : DiffSingerBasePhonemizer {
        protected override string GetDictionaryName()=>"dsdict-nan.yaml";
        public override string GetLangCode()=>"nan";
        protected override string[] Romanize(IEnumerable<string> lyrics) {
            return Pinyin.TaiLo.Instance.HanziToPinyin(lyrics.ToList(), MinTone.Style.NORMAL, Pinyin.Error.Default).Select(res => res.pinyin).ToArray();
        }
    }
}
