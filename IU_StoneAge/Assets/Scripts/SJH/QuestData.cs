using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public static string[] questNPCs =
    {
        "GrandFather",
        "GrandFather",
        "GrandFather",
        "Crafting_NPC_1",
        "Crafting_NPC_1",
        "Fishing_NPC_2",
        "Crafting_NPC_1",
        "Praying_NPC_1",
        "GrandFather",
        "GrandFather",
        "Crafting_NPC_1",
        "GrandFather",
        "Crafting_NPC_1",
        "GrandFather",
        "GrandFather"
    };
    public static string[,] scriptingNPCs =
    {
        {"Player", "Player", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
        {"GrandFather", "Player", "GrandFather", "GrandFather", "Player", "GrandFather", "GrandFather", null, null, null, null, null, null, null, null, null, null, null, null, null},
        {"GrandFather", "Player", "GrandFather", "GrandFather", "Player", "GrandFather", null, null, null, null, null, null, null, null, null, null, null, null, null, null},
        {"Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Crafting_NPC_1", "Player", null, null, null, null, null, null, null, null, null, null, null},
        {"Crafting_NPC_1", "Crafting_NPC_1", "Crafting_NPC_1", "Player", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
        {"Fishing_NPC_2", "Player", "Fishing_NPC_2", "Fishing_NPC_2", "Player", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
        {"Crafting_NPC_1", "Player", "Fishing_NPC_2", "Fishing_NPC_2", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
        {"Praying_NPC_1", "Player", "Fishing_NPC_2", "Player", "Praying_NPC_1", "Praying_NPC_1", "Player", "Praying_NPC_1", null, null, null, null, null, null, null, null, null, null, null, null},
        {"GrandFather", "Player", "GrandFather", "Player", "GrandFather", "GrandFather", "Player", "GrandFather", "GrandFather", "Player", "GrandFather", "Player", "GrandFather", "Player", "GrandFather", "Player", "GrandFather", "Player", "GrandFather", null},
        {"GrandFather", "Player", "GrandFather", "Player", "GrandFather", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
        {"Crafting_NPC_1", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", "Crafting_NPC_1", null, null, null, null, null, null},
        {"GrandFather", "Player", "GrandFather", "Player", "GrandFather", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
        {"Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Crafting_NPC_1", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", "Crafting_NPC_1", "Player", null, null, null, null},
        {"GrandFather", "GrandFather", "GrandFather", "GrandFather", "Player", "GrandFather", "Player", null, null, null, null, null, null, null, null, null, null, null, null, null},
        {"GrandFather", "Player", "GrandFather", "Player", "GrandFather", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null}
    };
    public static string[,] questScripts =
    {
        {
            "오늘도 아침 운동으로 하루를 시작해보자!",
            "항상 가던 길이라 익숙한지 반짝거리는걸! 따라가자!",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "반갑구나. 난 돌영감이다.",
            "알아요! 마을 최고 석기장인이시잖아요!",
            "그래, 근데 난 이제 돌을 칠 힘이 없구나...",
            "그래서 너가 나를 도와주지 않으련? 전부터 너의 성실함이 마음에 들었단다.",
            "한번해볼게요. 무엇을 도와드릴까요?",
            "이 할아버지를 도와 석기를 만들자꾸나.",
            "방법을 알려줄테니 내 공방에서 만들어 보거라.",
            null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "너라면... 대장간을 맡길만 할지도 모르겠구나.",
            "할아버지, 어디 가세요?",
            "나도 이제 옛날같지 않다. 하나뿐인 제자는 실력은 있지만 버릇이 없어....떼잉 쯧.",
            "마침 곤란던 차에 널 알았지. 그래, 이 할애비에게 석기제작을 배워보지 않으련?",
            "한 번 해볼게요...",
            "그래, 넌 재능도 있으니 잘할게다. 제자가 된 기념으로 뗀석기를 한 번 만들어 보거라.",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "너, 운이 좋았네. 마지막이겠지만.",
            "할아버지께서 재능있다고 하셨어요.",
            "그래봤자 할아버지의 공방은 내꺼야. 날 이길 수 없을걸?",
            "공방은 관심없어요..",
            "그러든가. 그럼 석기 제작으로 승부를 보자. 앞으로 진 사람이 이긴 사람 허드렛일 해주기로.",
            "허드렛일....?",
            "심부름말이야. 만들고 할아버지께 가져가. 할아버지가 점수를 매겨주실거다.",
            "결국엔 내가 이기겠지만. 그럼 가봐",
            "자기 할 말만 하네... 우이씽... 내가 이겨서 코를 납작하게 눌러준다!",
            null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "거봐. 내가 이겼지?",
            "요즘 할아버지가 편찮으셔. 식사도 내가 준비하고 있지.",
            "그래서 말인데 물가에서 물고기를 좀 구해와. 난 저녁 준비를 하고 있을테니.",
            "할아버지가 몸이 많이 안 좋으셨구나... 일단 물가로 가보자.",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "너... 구석에 있는 집에 사는 애 맞지?",
            "저를 아세요?",
            "그래.. 알다마다....흠흠",
            "물고기를 잡으러 왔니? 내가 도와줄테니 빨리 잡고 가라.",
            "감사합니다!",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "큰일이야! 할아버지가 사라지셨어.",
            "네? 할아버지가요?",
            "원래 공방밖으로 잘 나가지도 않는 분인데.... 같이 찾아보자.",
            "내가 마을밖을 찾아볼테니 넌 마을 주민들에게 할아버지를 본적있는지 물어봐. 찾으면 알려주기다!",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "아까 너희집쪽으로 가시던걸?",
            "제 집은 어떻게 아세요?",
            "내가 이 마을의 촌장이기 때문이지. 난 마을의 중앙에서 마을의 안녕을 빌고 지켜보는 게 일이란다.",
            "몰랐어요...",
            "마을사람들이 밖에서 들어왔던 너희 가족을 인정하려 하지 않았으니까. 대화를 나눌 일이 적었던 너는 모르는게 당연하단다.",
            "하지만.. 이제 널 받아들일 준비가 된것같기도 하구나. 뒤늦게라도...",
            "그게 무슨 말씀이세요?",
            "내가 너를 너무 오래 붙잡았구나. 할아버지를 찾아야지. 어서 가보렴.",
            null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "그래, 석기 만들기는 잘 되고 있나?",
            "네. 00이 자꾸 이상한 심부름을 시키긴 하지만....",
            "하하하. 그녀석 툴툴대긴 해도 나쁜 녀석은 아니다. 속은 꽤 깊은 아이야.",
            "네...",
            "일단 사과를 하고 싶구나.",
            "너희 부모님의 일은.... 나도 참 안타깝게 생각해.",
            "....저희 부모님에 대해 아세요?",
            "너희 어머니가 아플때 마을 사람들은 외면했지. 지금도 후회하고 있어.",
            "약초를 구하기 위해 네 아버지는 홀로 마을을 나갔고 다시 돌아오지 않았지... 약초를 구하지도, 무언갈 먹지도 못한 네 어머니는 끝내..",
            "그만! 그만해주세요.. 제발...",
            "... 미안하다.",
            "저희가 힘들때는 보지도 않고 이제와서 사과하시는 건가요? 이제 아빠도, 엄마도 그 사과를 받을 수 없는데...",
            "네 아버지가.. 떠나기전에... 널 부탁한다는 말을 남겼단다. 그래서 널 계속 지켜봤던거고. 잘 커줘서 고맙구나.",
            "....",
            "그래서 난 마을사람들이 널 받아들이도록 노력할거다. 내가 이세상을 떠나기전에.. 너가 혼자 살아갈 수 있도록... 내 최선을 다하마.",
            "마을 사람들이 저를 피하는 건 알고 있었어요. 혹시라도 아빠가 보일까봐 내일 아침마다 마을을 돌 때... 사람들이 저를 어떻게 보는지도요.",
            "어린 널.... 더이상 혼자두지 않을거다. 정말 내 손자로 들이고 싶은데... 날 용서해줄 수 있겠니?",
            "저도 모르겠어요. 하지만... 아빠의 마지막말이 그랬다면... 아빠의 말을 따르고 싶어요.",
            "고맙구나. 정말 고마워. 그럼 집을 정리하고 할아버지집으로 오렴. 원한다면 정리하지 않아도 돼. 이따보자꾸나."
            , null
        },
        {
            "이 할아버지가 맛있는 걸 해주마. 뭐 먹고 싶은거 있니?",
            "맛있는거... 아! 00이!",
            "응? 00이가 아무리 괴롭혀도 먹는건 아니란다..",
            "아니요 할아버지. 00이랑 할아버지를 찾고 있었어요! 할아버지가 안보인다고... 찾으면 알려주기로 했는데.... 깜박했다..",
            "아이고, 이 할아버지 찾느라 고생 꽤나 하고있겠구나. 어서 말해주러 가렴.",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "할아버지를? 정말.... 정말 다행이네. 고생했어. 고맙다.",
            "할아버지는 갈 곳 없는 날 거둬주신 고마운 분이셔. 부모님은... 사냥을 나갔다가 돌아오지 않았다는 흔한 얘기지 뭐.",
            "그게 흔한가요?",
            "솔직히 저 큰 녀석들을 사람이 맨 손으로 때려잡는 게 쉽겠어?",
            "맨 손이 아니라면요?",
            "뭐라고?",
            "맨 손이 아니라면.... 좋은 무기와 도구를 가진다면 사람들이 많이 돌아올까요?",
            "허, 당연한 소릴 하고 있네. 맨손보단 도구가 낫겠지.",
            "더 좋은 도구라면 더 많은 사람이 살아 돌아오겠죠?",
            "너 설마....",
            "공방은 제가 이을거에요. 좋은 석기를 만들어서 많은 사람을 살릴거에요.",
            "욕심이 없는 것 같았는데.",
            "아빠도.... 좋은 도구가 있었다면 빨리 돌아올 수 있었겠죠?",
            ".... 배고파서 난 밥이나 먹어야겠다. 넌 할아버지한테나 가봐.",
            null, null, null, null, null, null
        },
        {
            "내가 너에게 석기를 만드는 방법을 한가지만 알려주었더구나. 이제 다른 방법도 알아야지.",
            "어서 알려주세요!",
            "녀석, 그만 보채거라. 전보다 의욕이 넘치는 것같은데 또 내기라도 걸었니?",
            "공방은 제가 할거에요! 하고싶어요!",
            "눈에 생기가 돌고 있구나... 그래, 공방으로 가자. 새 석기를 만들어보자꾸나.", 
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "할아버지한테는 갔다 왔어?",
            "네.",
            "공방을... 그러니까 너가 할아버지의 후계자가 되고 싶다는거지?",
            "네.",
            "후.... 그래. 너도 알다시피 할아버지의 제자는 나뿐이었어.",
            "너가 없었다면 내가 공방을 이어 받았겠지. 언젠가 할아버지가 돌아가신다면 내게 남는 건 공방뿐이야.",
            "그러니까 나도 공방을 포기할 수 없어. 서로 후계자 자리를 두고 겨루자, 누가 더 나은 석기를 만드는지.",
            "좋은 석기를 만든다니요?",
            "알맞은 돌과 세기로 만들어서 더 날카롭고 단단한 석기를 만드는 사람이 이기는 거야. 뗀석기와 간석기 둘다.",
            "좋아요! 제가 이겨도 말바꾸지 마세요!",
            "난 내가 한 말은 지켜. 그리고.... 이제는 형이라 불러라. 말도 편하게 하고.",
            "네? 뭐라고요?",
            "....형...이라 부르라고... 가..가라!",
            "형 얼굴이 빨개진 것 같은데!",
            "화내기 전에 가라.",
            "네, 형!",
            null, null, null, null
        },
        {
            "그래. 이제 누가 내 공방을 받을지 정하자꾸나.",
            "....으음.....",
            ".......",
            "00아 미안하지만 이번엔 너가 진것같구나.",
            "감사합니다.. 감사합니다, 할아버지!",
            "00이는 나랑 잠깐 얘기하자꾸나. 그동안 너는 장작과 물고기를 구해오겠니?",
            "네. 다녀올게요.",
            null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "자, 이제 앞으로는 네가 공방의 주인이다.",
            "네? 벌써요?",
            "나도 이제 쉬어야지. 이젠 안돼, 안돼. 앞으로는 공방에 대해 알려주마.",
            "네....",
            "공방에서 석기도 판매할테니 마을 사람들에게 홍보 좀 하고 와라. 농장부터 가라. 우리 공방에 가장 많이 오는 분들이다.",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        }
    };
    public static string[,] finishNPCs =
    {
        { "GrandFather", null, null, null },
        { "GrandFather", null, null, null },
        { "GrandFather", null, null, null },
        { "GrandFather", "Player", "GrandFather", null },
        { "Fishing_NPC_2", null, null, null },
        { "Crafting_NPC_1", null, null, null },
        { "Praying_NPC_1", null, null, null },
        { "GrandFather", null, null, null },
        { "GrandFather", null, null, null },
        { "Crafting_NPC_1", null, null, null },
        { "GrandFather", null, null, null },
        { "GrandFather", null, null, null },
        { "Crafting_NPC_1", null, null, null },
        { "GrandFather", null, null, null },
        { "Farmming_NPC_1", null, null, null }
    };
    public static string[,] finishScripts =
    {
        { "어서오거라", null, null, null },
        { "해냈구나. 그래, 너라면 잘 할거라 생각했다.", null, null, null },
        { "좋은 석기구나. 내 제자가 된 걸 축하한다.", null, null, null },
        { "흠... 아무래도 아직 경험을 이길 순 없는 것 같구나. 너가 졌다.", "말도 안돼!", "둘이서 내기를 했다지? 다시 00이한테 가보거라.", null },
        { "음? 낚시를 하러 왔니?", null, null, null },
        { "처음치곤 괜찮은 물고기네. 수고했어.", null, null, null },
        { "돌영감말이야? 내가 봤지. 난 매일 여기서 기도를 드리거든.", null, null, null },
        { "응? 어디 갔던 게냐? 너에게 말해줄게 있어서 너희집을 찾아왔다.", null, null, null },
        { "아가야, 어서 오렴.", null, null, null },
        { "야.. 너... 어디갔다 이제 온거야?", null, null, null },
        { "어서오렴. 마침 부탁할 게 있었단다.", null, null, null },
        { "석기를 완성했구나. 잘했다. 00이가 할 말이 있는 것 같더구나.", null, null, null },
        { "다 만들었나? 누가 이겼는지는 할아버지가 보고 말해주실거야. 할아버지한테 가자.", null, null, null },
        { "수고했다. 좀 쉬다가 다시 오거라.", null, null, null },
        { "공방에서 석기도 판매할테니 마을 사람들에게 홍보 좀 하고 와라. 농장부터 가라. 우리 공방에 가장 많이 오는 분들이다.", null, null, null }
    };

    // 0: 뗀석기 1: 간석기 2: 낚시
    public static int[] game =
    {
        -1, 0, 0, 0, -1, 2, -1, -1, -1, -1, -1, 1, 1, 2, 1
    };
}
