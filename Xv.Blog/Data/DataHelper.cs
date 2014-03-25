namespace Xv.Blog.Data
{
    using System;
    using System.Linq;

    public static class DataHelper
    {
        public const string LoremIpsum =
            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed iaculis ullamcorper ligula, a mattis risus vestibulum ac. Maecenas pulvinar purus vitae tellus gravida blandit. Praesent vel turpis molestie, dapibus urna at, pharetra felis. Morbi gravida lectus eget nulla fermentum, vitae tristique diam aliquam. Aliquam eu justo sapien. In quis ultricies nibh, sit amet posuere lorem. Donec risus nunc, vehicula vitae eleifend ut, venenatis sed lectus. Cras sed bibendum lorem, molestie auctor lacus. Proin tincidunt sem et justo sollicitudin condimentum. Fusce eget ante at justo aliquet lacinia nec ut magna. In tempus quam velit, ultricies vehicula nisi viverra eu. Fusce gravida nibh ligula, in cursus ipsum malesuada lacinia. In venenatis in nisl a congue.

Donec venenatis posuere leo, id semper nisl suscipit sit amet. Pellentesque a pellentesque nulla. Praesent vel fermentum odio. Quisque gravida ornare metus sit amet egestas. Vestibulum tempor tincidunt mi nec tincidunt. Quisque pellentesque at elit eu laoreet. Ut pretium nisl ac consectetur feugiat. Vivamus sit amet erat mauris. Ut quam lorem, semper vel metus quis, facilisis interdum est. Pellentesque viverra adipiscing felis vel ornare. Cras sed orci sodales ipsum posuere placerat quis non urna. Fusce ut vehicula massa. Fusce aliquam quam adipiscing, viverra augue at, consequat elit. Mauris pellentesque, mi quis malesuada eleifend, quam leo pellentesque sapien, semper elementum massa elit ac augue.

Nullam mollis libero at lacus elementum, a egestas justo auctor. Fusce porta pharetra venenatis. Sed vitae tempus libero. Fusce eget augue id odio venenatis ornare. Fusce faucibus pellentesque venenatis. Sed lectus dolor, ultrices eu iaculis et, tempor vel nibh. Praesent porta nisl ut lobortis tristique. Curabitur vehicula leo non magna aliquet auctor. Suspendisse eu urna mattis, lacinia leo sed, ullamcorper quam. Vestibulum sit amet nisi sodales, bibendum ante sed, fermentum lorem. Curabitur elementum ultricies orci non aliquam. Quisque magna nulla, condimentum sit amet facilisis a, condimentum ut magna. Donec sed porta ligula.

Sed interdum diam nisl, in scelerisque quam molestie vel. Phasellus commodo lectus at sapien venenatis commodo sit amet eget odio. Maecenas iaculis arcu tellus, id aliquet velit tempor in. Duis ornare laoreet dapibus. Quisque cursus nunc odio, vel dapibus augue gravida pellentesque. Vivamus placerat eleifend lacus nec interdum. Nulla vel erat odio. Sed laoreet vehicula urna, tempor viverra enim consequat tincidunt. Curabitur sit amet porta purus. Mauris in cursus neque.

Phasellus at convallis erat. Curabitur varius metus quis vehicula consectetur. Aenean fringilla sem et vulputate adipiscing. Sed sed libero non eros imperdiet aliquam. Duis gravida vulputate purus porta vulputate. Integer commodo ante quis lorem tincidunt ullamcorper. Curabitur at purus ut purus imperdiet faucibus ut et nunc. Cras quis pharetra sapien. Suspendisse potenti.

Vestibulum at molestie tortor, at ullamcorper erat. In feugiat eget quam non lacinia. Suspendisse at egestas dui. Phasellus nec metus eu ipsum convallis tristique non vel eros. Sed quis interdum dolor. Curabitur faucibus nisl sed magna sodales dignissim sed eu sapien. Cras feugiat feugiat justo sed ullamcorper. Integer eros nisi, porta ut nisl vitae, pellentesque blandit lectus. Mauris porta ipsum mi, vel pellentesque lectus suscipit at. Phasellus nisl justo, vulputate sit amet vestibulum a, cursus ac ante.

In dapibus in sapien sed accumsan. Nullam eu dolor odio. Nulla et vulputate mauris. Fusce augue tortor, consectetur ac justo sit amet, ullamcorper sagittis augue. In aliquet et nibh eu suscipit. Aliquam volutpat ultricies convallis. Aliquam et facilisis lectus. Integer vitae facilisis odio. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae;

Morbi vitae leo felis. Fusce molestie non lacus id pulvinar. Ut sed ornare ligula. Quisque ut lobortis sem, eget aliquam lectus. Duis sed posuere purus. In in nunc consequat, placerat dolor a, pharetra nisl. Nullam congue est urna, eget convallis risus adipiscing sed. Sed volutpat, dolor in tempor consequat, ante ante gravida metus, id convallis magna purus et dolor. Donec consequat malesuada urna. Nam quis orci elit. Phasellus pulvinar est at sem adipiscing, eget consectetur diam tincidunt. Vivamus et augue ac ipsum dictum faucibus a at lorem. Praesent vitae risus varius, pellentesque tellus in, dictum erat. Nam at volutpat risus. Nullam et massa sodales, feugiat nunc id, commodo mauris. Vivamus sagittis lacus nec felis lobortis, ut molestie dui egestas.

Aliquam tortor orci, venenatis sed sodales vitae, condimentum eget quam. Etiam iaculis arcu in mi fermentum vulputate. Duis condimentum ante tortor, mattis blandit neque molestie id. Nulla vitae odio vitae magna adipiscing condimentum. Ut sit amet tempus odio. Fusce a lorem nibh. Suspendisse dictum, velit id tincidunt viverra, odio nunc suscipit est, quis vehicula nibh leo vel ipsum. Aliquam mi mi, varius eget lacinia vitae, pretium id turpis. Nam bibendum ligula et sollicitudin aliquet. Proin lectus lacus, rutrum vel risus quis, mattis dapibus sapien. In auctor justo eget justo mollis consequat. Praesent et mi id diam dictum vehicula. Curabitur vehicula elementum nulla quis ullamcorper. Aliquam quis enim eget massa porttitor sollicitudin eget sed nunc. Suspendisse vehicula, quam eu fringilla euismod, orci dui bibendum odio, sed consectetur orci purus ac elit.

Nullam fringilla ornare sollicitudin. Donec mattis felis urna, vel sodales odio rhoncus sit amet. Donec sit amet orci est. Maecenas nec consequat diam, sed elementum enim. Nam eu adipiscing augue. Maecenas sed enim ornare leo consectetur luctus. Praesent vel orci egestas, convallis massa et, tincidunt eros. Donec ante est, aliquet id cursus quis, eleifend in justo. In hac habitasse platea dictumst. In elit risus, tristique laoreet diam pharetra, tristique sodales augue. Nunc luctus quam est, nec varius elit commodo accumsan. Proin congue lorem ipsum, ut placerat ante iaculis eu. Proin eget consectetur sapien. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Suspendisse nec sem blandit, iaculis odio nec, laoreet tortor. Nulla a neque in augue adipiscing elementum id non ligula.

Nam non purus metus. Suspendisse felis ligula, dapibus sed pretium vel, fermentum a tortor. Nullam tempus rutrum lorem sed tincidunt. Sed eu libero massa. Duis pulvinar tellus dolor, luctus ultricies dolor luctus non. Sed a justo dolor. Curabitur elementum id felis non commodo. Praesent dolor justo, cursus in malesuada et, vulputate vel felis.

Nullam at dignissim metus. Nullam turpis libero, dapibus vitae egestas sed, lacinia id libero. Quisque lectus nisi, mattis at felis sed, pellentesque posuere sapien. Fusce sem dolor, mollis vel euismod a, feugiat vitae lacus. Fusce lacus purus, viverra ut convallis nec, facilisis et metus. Integer posuere mi id dolor eleifend, vel tempor neque adipiscing. Duis dignissim posuere rutrum. Ut fermentum dui enim, at auctor quam congue pharetra. Proin dui augue, condimentum at orci a, blandit vehicula tellus. Proin tincidunt felis velit, ut pulvinar magna lacinia at. Nunc in massa lacus.

Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Morbi pharetra massa elit, ac elementum lectus auctor et. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Praesent laoreet egestas metus a tincidunt. Nunc commodo mattis risus, ut tincidunt nisi mollis at. Praesent aliquam volutpat mollis. Curabitur sem lorem, pellentesque sed sem vitae, porttitor ultrices nunc. Ut turpis est, adipiscing ut volutpat nec, dapibus vel dolor.

Donec viverra ligula quis felis aliquet lacinia. Proin posuere magna et neque varius, non fermentum justo lacinia. Donec eu dignissim urna. Nam porttitor, ligula eu imperdiet volutpat, tellus nunc sagittis nunc, eget suscipit velit eros sit amet mi. Ut bibendum, lectus nec cursus dignissim, quam dui cursus odio, eget egestas sapien turpis nec neque. Pellentesque est tellus, facilisis vel fermentum vel, commodo euismod massa. Donec gravida, tellus sed dictum facilisis, enim ipsum auctor ante, in pretium metus neque quis leo. Fusce commodo leo lectus, pulvinar blandit libero bibendum quis. In placerat velit id urna faucibus, non luctus odio imperdiet. Nulla porta sollicitudin euismod. Aliquam facilisis nisl non faucibus mollis. Nulla sed fringilla felis, non egestas ipsum. Duis molestie turpis eget nulla eleifend dignissim.

In cursus nec enim a pulvinar. Praesent sed bibendum massa. Donec vitae egestas massa, quis ultrices purus. Sed id convallis orci. Quisque tristique sit amet lorem non rutrum. Proin vitae lectus congue, sollicitudin metus non, sodales urna. Proin elementum euismod pretium. Fusce vestibulum, elit sed adipiscing bibendum, turpis ipsum porta turpis, mattis pharetra diam mauris ac nisl. Nunc egestas nibh non dui sagittis, quis semper neque sodales. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis leo dolor, tristique in diam vitae, commodo ultricies justo. Nunc scelerisque feugiat orci.";

        private static Random rand = new Random();

        public static string GetLipsumHtml()
        {
            var numParagraphs = 5 + rand.Next(3);
            var paras =
                LoremIpsum.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries)
                    .OrderBy(x => Guid.NewGuid())
                    .Take(numParagraphs)
                    .Select(x => "<p>" + x.Trim() + "</p>");

            return string.Join("\n", paras);
        }
    }
}