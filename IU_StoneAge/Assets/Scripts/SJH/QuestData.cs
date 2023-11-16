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
            "���õ� ��ħ ����� �Ϸ縦 �����غ���!",
            "�׻� ���� ���̶� �ͼ����� ��¦�Ÿ��°�! ������!",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "�ݰ�����. �� �������̴�.",
            "�˾ƿ�! ���� �ְ� ���������̽��ݾƿ�!",
            "�׷�, �ٵ� �� ���� ���� ĥ ���� ������...",
            "�׷��� �ʰ� ���� �������� ������? ������ ���� �������� ������ ����ܴ�.",
            "�ѹ��غ��Կ�. ������ ���͵帱���?",
            "�� �Ҿƹ����� ���� ���⸦ �����ڲٳ�.",
            "����� �˷����״� �� ���濡�� ����� ���Ŷ�.",
            null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "�ʶ��... ���尣�� �ñ游 ������ �𸣰ڱ���.",
            "�Ҿƹ���, ��� ������?",
            "���� ���� �������� �ʴ�. �ϳ����� ���ڴ� �Ƿ��� ������ ������ ����....���� ��.",
            "��ħ ����� ���� �� �˾���. �׷�, �� �Ҿֺ񿡰� ���������� ������� ������?",
            "�� �� �غ��Կ�...",
            "�׷�, �� ��ɵ� ������ ���ҰԴ�. ���ڰ� �� ������� �����⸦ �� �� ����� ���Ŷ�.",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "��, ���� ���ҳ�. �������̰�����.",
            "�Ҿƹ������� ����ִٰ� �ϼ̾��.",
            "�׷����� �Ҿƹ����� ������ ������. �� �̱� �� ������?",
            "������ ���ɾ����..",
            "�׷��簡. �׷� ���� �������� �ºθ� ����. ������ �� ����� �̱� ��� ��巿�� ���ֱ��.",
            "��巿��....?",
            "�ɺθ����̾�. ����� �Ҿƹ����� ������. �Ҿƹ����� ������ �Ű��ֽǰŴ�.",
            "�ᱹ�� ���� �̱������. �׷� ����",
            "�ڱ� �� ���� �ϳ�... ���̾�... ���� �̰ܼ� �ڸ� �����ϰ� �����ش�!",
            null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "�ź�. ���� �̰���?",
            "���� �Ҿƹ����� ��������. �Ļ絵 ���� �غ��ϰ� ����.",
            "�׷��� ���ε� �������� ����⸦ �� ���ؿ�. �� ���� �غ� �ϰ� �����״�.",
            "�Ҿƹ����� ���� ���� �� �����̱���... �ϴ� ������ ������.",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "��... ������ �ִ� ���� ��� �� ����?",
            "���� �Ƽ���?",
            "�׷�.. �˴ٸ���....����",
            "����⸦ ������ �Դ�? ���� �������״� ���� ��� ����.",
            "�����մϴ�!",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "ū���̾�! �Ҿƹ����� ������̾�.",
            "��? �Ҿƹ�������?",
            "���� ��������� �� �������� �ʴ� ���ε�.... ���� ã�ƺ���.",
            "���� �������� ã�ƺ��״� �� ���� �ֹε鿡�� �Ҿƹ����� �����ִ��� �����. ã���� �˷��ֱ��!",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "�Ʊ� ������������ ���ô���?",
            "�� ���� ��� �Ƽ���?",
            "���� �� ������ �����̱� ��������. �� ������ �߾ӿ��� ������ �ȳ��� ���� ���Ѻ��� �� ���̶���.",
            "�������...",
            "����������� �ۿ��� ���Դ� ���� ������ �����Ϸ� ���� �ʾ����ϱ�. ��ȭ�� ���� ���� ������ �ʴ� �𸣴°� �翬�ϴܴ�.",
            "������.. ���� �� �޾Ƶ��� �غ� �ȰͰ��⵵ �ϱ���. �ڴʰԶ�...",
            "�װ� ���� �����̼���?",
            "���� �ʸ� �ʹ� ���� ����ұ���. �Ҿƹ����� ã�ƾ���. � ������.",
            null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "�׷�, ���� ������ �� �ǰ� �ֳ�?",
            "��. 00�� �ڲ� �̻��� �ɺθ��� ��Ű�� ������....",
            "������. �׳༮ ������� �ص� ���� �༮�� �ƴϴ�. ���� �� ���� ���̾�.",
            "��...",
            "�ϴ� ����� �ϰ� �ͱ���.",
            "���� �θ���� ����.... ���� �� ��Ÿ���� ������.",
            "....���� �θ�Կ� ���� �Ƽ���?",
            "���� ��Ӵϰ� ���ö� ���� ������� �ܸ�����. ���ݵ� ��ȸ�ϰ� �־�.",
            "���ʸ� ���ϱ� ���� �� �ƹ����� Ȧ�� ������ ������ �ٽ� ���ƿ��� �ʾ���... ���ʸ� ��������, ���� ������ ���� �� ��Ӵϴ� ����..",
            "�׸�! �׸����ּ���.. ����...",
            "... �̾��ϴ�.",
            "���� ���鶧�� ������ �ʰ� �����ͼ� ����Ͻô� �ǰ���? ���� �ƺ���, ������ �� ����� ���� �� ���µ�...",
            "�� �ƹ�����.. ����������... �� ��Ź�Ѵٴ� ���� ����ܴ�. �׷��� �� ��� ���Ѻô��Ű�. �� Ŀ�༭ ������.",
            "....",
            "�׷��� �� ����������� �� �޾Ƶ��̵��� ����ҰŴ�. ���� �̼����� ����������.. �ʰ� ȥ�� ��ư� �� �ֵ���... �� �ּ��� ���ϸ�.",
            "���� ������� ���� ���ϴ� �� �˰� �־����. Ȥ�ö� �ƺ��� ���ϱ�� ���� ��ħ���� ������ �� ��... ������� ���� ��� ����������.",
            "� ��.... ���̻� ȥ�ڵ��� �����Ŵ�. ���� �� ���ڷ� ���̰� ������... �� �뼭���� �� �ְڴ�?",
            "���� �𸣰ھ��. ������... �ƺ��� ���������� �׷��ٸ�... �ƺ��� ���� ������ �;��.",
            "������. ���� ����. �׷� ���� �����ϰ� �Ҿƹ��������� ����. ���Ѵٸ� �������� �ʾƵ� ��. �̵����ڲٳ�."
            , null
        },
        {
            "�� �Ҿƹ����� ���ִ� �� ���ָ�. �� �԰� ������ �ִ�?",
            "���ִ°�... ��! 00��!",
            "��? 00�̰� �ƹ��� �������� �Դ°� �ƴ϶���..",
            "�ƴϿ� �Ҿƹ���. 00�̶� �Ҿƹ����� ã�� �־����! �Ҿƹ����� �Ⱥ��δٰ�... ã���� �˷��ֱ�� �ߴµ�.... �����ߴ�..",
            "���̰�, �� �Ҿƹ��� ã���� ��� �ϳ� �ϰ��ְڱ���. � �����ַ� ����.",
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "�Ҿƹ�����? ����.... ���� �����̳�. ����߾�. ����.",
            "�Ҿƹ����� �� �� ���� �� �ŵ��ֽ� ���� ���̼�. �θ����... ����� �����ٰ� ���ƿ��� �ʾҴٴ� ���� ����� ��.",
            "�װ� ���Ѱ���?",
            "������ �� ū �༮���� ����� �� ������ ������� �� ���ھ�?",
            "�� ���� �ƴ϶���?",
            "�����?",
            "�� ���� �ƴ϶��.... ���� ����� ������ �����ٸ� ������� ���� ���ƿñ��?",
            "��, �翬�� �Ҹ� �ϰ� �ֳ�. �Ǽպ��� ������ ������.",
            "�� ���� ������� �� ���� ����� ��� ���ƿ�����?",
            "�� ����....",
            "������ ���� �����ſ���. ���� ���⸦ ���� ���� ����� �츱�ſ���.",
            "����� ���� �� ���Ҵµ�.",
            "�ƺ���.... ���� ������ �־��ٸ� ���� ���ƿ� �� �־�����?",
            ".... ����ļ� �� ���̳� �Ծ�߰ڴ�. �� �Ҿƹ������׳� ����.",
            null, null, null, null, null, null
        },
        {
            "���� �ʿ��� ���⸦ ����� ����� �Ѱ����� �˷��־�������. ���� �ٸ� ����� �˾ƾ���.",
            "� �˷��ּ���!",
            "�༮, �׸� ��ä�Ŷ�. ������ �ǿ��� ��ġ�� �Ͱ����� �� ����� �ɾ���?",
            "������ ���� �Ұſ���! �ϰ�;��!",
            "���� ���Ⱑ ���� �ֱ���... �׷�, �������� ����. �� ���⸦ �����ڲٳ�.", 
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "�Ҿƹ������״� ���� �Ծ�?",
            "��.",
            "������... �׷��ϱ� �ʰ� �Ҿƹ����� �İ��ڰ� �ǰ� �ʹٴ°���?",
            "��.",
            "��.... �׷�. �ʵ� �˴ٽ��� �Ҿƹ����� ���ڴ� �����̾���.",
            "�ʰ� �����ٸ� ���� ������ �̾� �޾Ұ���. ������ �Ҿƹ����� ���ư��Ŵٸ� ���� ���� �� ������̾�.",
            "�׷��ϱ� ���� ������ ������ �� ����. ���� �İ��� �ڸ��� �ΰ� �ܷ���, ���� �� ���� ���⸦ �������.",
            "���� ���⸦ ����ٴϿ�?",
            "�˸��� ���� ����� ���� �� ��ī�Ӱ� �ܴ��� ���⸦ ����� ����� �̱�� �ž�. ������� ������ �Ѵ�.",
            "���ƿ�! ���� �̰ܵ� ���ٲ��� ������!",
            "�� ���� �� ���� ����. �׸���.... ������ ���̶� �ҷ���. ���� ���ϰ� �ϰ�.",
            "��? ������?",
            "....��...�̶� �θ����... ��..����!",
            "�� ���� ������ �� ������!",
            "ȭ���� ���� ����.",
            "��, ��!",
            null, null, null, null
        },
        {
            "�׷�. ���� ���� �� ������ ������ �����ڲٳ�.",
            "....����.....",
            ".......",
            "00�� �̾������� �̹��� �ʰ� ���Ͱ�����.",
            "�����մϴ�.. �����մϴ�, �Ҿƹ���!",
            "00�̴� ���� ��� ������ڲٳ�. �׵��� �ʴ� ���۰� ����⸦ ���ؿ��ڴ�?",
            "��. �ٳ�ðԿ�.",
            null, null, null, null, null, null, null, null, null, null, null, null, null
        },
        {
            "��, ���� �����δ� �װ� ������ �����̴�.",
            "��? �����?",
            "���� ���� �������. ���� �ȵ�, �ȵ�. �����δ� ���濡 ���� �˷��ָ�.",
            "��....",
            "���濡�� ���⵵ �Ǹ����״� ���� ����鿡�� ȫ�� �� �ϰ� �Ͷ�. ������� ����. �츮 ���濡 ���� ���� ���� �е��̴�.",
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
        { "����Ŷ�", null, null, null },
        { "�س±���. �׷�, �ʶ�� �� �ҰŶ� �����ߴ�.", null, null, null },
        { "���� ���ⱸ��. �� ���ڰ� �� �� �����Ѵ�.", null, null, null },
        { "��... �ƹ����� ���� ������ �̱� �� ���� �� ������. �ʰ� ����.", "���� �ȵ�!", "���̼� ���⸦ �ߴ���? �ٽ� 00������ �����Ŷ�.", null },
        { "��? ���ø� �Ϸ� �Դ�?", null, null, null },
        { "ó��ġ�� ������ ������. �����߾�.", null, null, null },
        { "���������̾�? ���� ����. �� ���� ���⼭ �⵵�� �帮�ŵ�.", null, null, null },
        { "��? ��� ���� �Գ�? �ʿ��� �����ٰ� �־ �������� ã�ƿԴ�.", null, null, null },
        { "�ư���, � ����.", null, null, null },
        { "��.. ��... ��𰬴� ���� �°ž�?", null, null, null },
        { "�����. ��ħ ��Ź�� �� �־��ܴ�.", null, null, null },
        { "���⸦ �ϼ��߱���. ���ߴ�. 00�̰� �� ���� �ִ� �� ��������.", null, null, null },
        { "�� �������? ���� �̰������ �Ҿƹ����� ���� �����ֽǰž�. �Ҿƹ������� ����.", null, null, null },
        { "�����ߴ�. �� ���ٰ� �ٽ� ���Ŷ�.", null, null, null },
        { "���濡�� ���⵵ �Ǹ����״� ���� ����鿡�� ȫ�� �� �ϰ� �Ͷ�. ������� ����. �츮 ���濡 ���� ���� ���� �е��̴�.", null, null, null }
    };

    // 0: ������ 1: ������ 2: ����
    public static int[] game =
    {
        -1, 0, 0, 0, -1, 2, -1, -1, -1, -1, -1, 1, 1, 2, 1
    };
}
