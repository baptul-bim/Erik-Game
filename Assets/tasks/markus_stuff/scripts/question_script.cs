using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class question_script : MonoBehaviour
{
    [SerializeField]
    //the answer buttons
    public TextMeshProUGUI[] answers;
    [SerializeField]
    public TextMeshProUGUI[] quest;
    //the questions 
     string[] questions= 
        {
        new string("defenestrate"),
        new string("echo"),
        new string("ash"),
        new string("wonder"),
        new string("elapse"),
        new string("egress"),
        new string("strange"),
        new string("opinion"),
        new string("race"),
        new string("ignoramos"),
        new string("spectrum"),
        new string("chaos"),
        new string("morbid"),
        new string("nighthawk"),
        new string("tomfoolery"),
        new string("autonomy"),
        new string("empirical"),
        new string("terrify"),
        new string("court"),
        new string("morsel"),
    };
    //the answers to the questions||the first answer in each row is the correct one 
     string[] answer=
    {
    new string("to throw somone out of a window"),new string("the act of removing a fenestrate"),new string("indicent exposure in a senate "),new string("the act of defending a senetor"),
    new string("a sound that reflects back on the listener"),new string("the act of mimicing another person"),new string("a device used to locate things"), new string("the act of reapeting an earlier mistake"),
    new string("the powder that remains after a fire"),new string("the act of being shocked"),new string("another word for whip"),new string("a long piece of cloth worn over the shoulder"),
    new string("a desire to know"),new string("the act of imagining "),new string("a type of bread"),new string("a person to travels aimlessly"),
    new string("for time to pass or go by"),new string("running away to get married"),new string("the act of falling down"),new string("a problematic habit such as an addiction returning"),
    new string("the act of leaving a place"),new string("the loss of progress"),new string("when somthing lacks grace"),new string("temporatriely leaving the main subject"),
    new string("somthing unusual or suprising"),new string("somthing that can hold a lot of wheight"),new string("somthing that is hard to break"),new string("a form of apperition"),
    new string("a view or judjment"),new string("a factually correct claim"),new string("a type of drug"),new string("an emotional response"),
    new string("a competition about being the fastest"),new string("a person"),new string("an outburst of anger"),new string("the act of collecting leaves"),
    new string("a stupid person"),new string("lacking knowledge on a subject"),new string("somone ignoring a obvius issue"),new string("somone falsely beliving themself to an expert"),
    new string("a band of colours"),new string("a type of mental disorder"),new string("the act of introspection"),new string("looking at somthing closely"),
    new string("compleat disorder and confusion"),new string("a spiecies of snake"),new string("a type of pastry"),new string("a medieval cookbook "),
    new string("an unusual intreast in maqabre subjects"),new string("a famous vampire"),new string("shorthand for biding more"),new string("a traditional hungarian dish"),
    new string("a person that is active at night"),new string("a plant commonly found in USA"),new string("a person with good nightvision"),new string("a european longbow "),
    new string("to behave in a silly manor"),new string("to trick somone into making a mistake"),new string("when the result of an action is nonsentical"),new string("when a tomcat causes trouble"),
    new string("the right to govern oneself"),new string("the structure of living things"),new string("another word for machine"),new string("to earn forgivness"),
    new string("an obsevation based on experience"),new string("a discriptor to signify inperial status"),new string("a word to mock the inperial family"),new string("a judgement based on emotion"),
    new string("couse to feel extrem fear"),new string("a descriptor of somthing good"),new string("a fried dish invented by terry Trautman"),new string("a word for heavy traffic"),
    new string("a romantic advance with the intention to marry"),new string("a form of transportation"),new string("another word for count"),new string("a noble title during the victorian era"),
    new string("a mouthfull of food"),new string("another word for mortal"),new string("a shorthand for 'more to sell'"),new string("a type of eel"),
    };
    //information holders please ignore
    private int question1;
    private int question2;
    private int question3;
    private int question4;
    private bool question1answerd;
    private bool question2answerd;
    private bool question3answerd;
    private bool question4answerd;
    private string answertoquestion1;
    private string answertoquestion2;
    private string answertoquestion3;
    private string answertoquestion4;
    private string correctanswer1;
    private string correctanswer2;
    private string correctanswer3;
    private string correctanswer4;

    // Start is called before the first frame update


    
    
    //selects the questions the questions
       void start_englishTask()
        {

        

          question1answerd = false;
        question2answerd = false;
        question3answerd = false;
        question4answerd = false;
        QustionPicker();
        }
    //randomly selects 4 different questions || turns on the questions
    private void QustionPicker()
    {
        System.Random rng = new System.Random();
        question1 = rng.Next(0, 20);
    questionCheck1:
        question2 = rng.Next(0, 20);
        if (question2 != question1)
        {
        questionCheck2:
            question3 = rng.Next(0, 20);
            if (question3 != question2 && question3 != question1)
            {
            questioncheck3:
                question4 = rng.Next(0, 20);
                if (question4 != question3 && question4 != question2 && question4 != question1)
                {
                    correctanswer1 = answer[question1*4];
                    print(correctanswer1 + "correct 1");
                    correctanswer2 = answer[question2 * 4];
                    print(correctanswer2+ "correct 2");
                    correctanswer3 = answer[question3 * 4];
                    print(correctanswer3 + "correct 3");
                    correctanswer4 = answer[question4 * 4];
                    print(correctanswer4 + "correct 4");
                    quest[0].text = questions[question1];
                    quest[1].text = questions[question2];
                    quest[2].text = questions[question3];
                    quest[3].text = questions[question4];
                    answerOrder();
                }
                else
                {
                    goto questioncheck3;
                }
            }
            else
            {
                goto questionCheck2;
            }
        }
        else
        {
            goto questionCheck1;
        }

    }
    //randomizes the order of the answers to each question and turns on the answer buttons 
    private void answerOrder()
    {
        System.Random rng = new System.Random();
       int answerslot1= rng.Next(0+(question1*4), 4+(question1*4));
    answerCheck1:
        int answerslot2 =rng.Next(0 + (question1*4), 4 + (question1*4));
        if(answerslot2!=answerslot1)
        {
        answerCheck2:
            int answerslot3 = rng.Next(0 + (question1*4), 4 + (question1*4));
            if(answerslot3!=answerslot1&&answerslot3!=answerslot2)
            {
            answercheck3:
                int answerslot4 = rng.Next(0 + (question1*4), 4 + (question1*4));
                if(answerslot4!=answerslot3&&answerslot4!=answerslot2&&answerslot4!=answerslot1)
                {
                    int answerslot12 = rng.Next(0 + (question2*4), 4 + (question2*4));
                answerCheck4:
                    int answerslot22 = rng.Next(0 + (question2*4), 4 + (question2*4));
                    if (answerslot22 != answerslot12)
                    {
                    answerCheck5:
                        int answerslot32 = rng.Next(0 + (question2*4), 4 + (question2*4));
                        if (answerslot32 != answerslot12 && answerslot32 != answerslot22)
                        {
                        answercheck6:
                            int answerslot42 = rng.Next(0 + (question2*4), 4 + (question2*4));
                            if (answerslot42 != answerslot32 && answerslot42 != answerslot22 && answerslot42 != answerslot12)
                            {
                                int answerslot13 = rng.Next(0 + (question3*4), 4 + (question3*4));
                            answerCheck7:
                                int answerslot23 = rng.Next(0 + (question3*4), 4 + (question3*4));
                                if (answerslot23 != answerslot13)
                                {
                                answerCheck8:
                                    int answerslot33 = rng.Next(0 + (question3)*4, 4 + (question3*4));
                                    if (answerslot33 != answerslot13 && answerslot33 != answerslot23)
                                    {
                                    answercheck9:
                                        int answerslot43 = rng.Next(0 + (question3*4), 4 + (question3*4));
                                        if (answerslot43 != answerslot33 && answerslot43 != answerslot23 && answerslot43 != answerslot13)
                                        {
                                            int answerslot14 = rng.Next(0 + (question4*4), 4 + (question4*4));
                                        answerCheck10:
                                            int answerslot24 = rng.Next(0 + (question4*4), 4 + (question4*4));
                                            if (answerslot24 != answerslot14)
                                            {
                                            answerCheck11:
                                                int answerslot34 = rng.Next(0 + (question4*4), 4 + (question4*4));
                                                if (answerslot34 != answerslot14 && answerslot34 != answerslot24)
                                                {
                                                answercheck12:
                                                    int answerslot44 = rng.Next(0 + (question4*4), 4 + (question4*4));
                                                    if (answerslot44 != answerslot34 && answerslot44 != answerslot24 && answerslot44 != answerslot14)
                                                    {
                                                        answers[0].text = answer[answerslot1];
                                                        answers[1].text = answer[answerslot2];
                                                        answers[2].text = answer[answerslot3];
                                                        answers[3].text= answer[answerslot4];
                                                        answers[4].text = answer[answerslot12];
                                                        answers[5].text = answer[answerslot22];
                                                        answers[6].text = answer[answerslot32];
                                                        answers[7].text = answer[answerslot42];
                                                        answers[8].text = answer[answerslot13];
                                                        answers[9].text= answer[answerslot23];
                                                        answers[10].text= answer[answerslot33];
                                                        answers[11].text= answer[answerslot43];
                                                        answers[12] .text= answer[answerslot14];
                                                        answers[13].text= answer[answerslot24];
                                                        answers[14].text = answer[answerslot34];
                                                        answers[15].text = answer[answerslot44];
                                                    }
                                                    else
                                                    {
                                                        goto answercheck12;
                                                    }
                                                }
                                                else
                                                {
                                                    goto answerCheck11;
                                                }
                                            }
                                            else
                                            {
                                                goto answerCheck10;
                                            }
                                        }
                                        else
                                        {
                                            goto answercheck9;
                                        }
                                    }
                                    else
                                    {
                                        goto answerCheck8;
                                    }
                                }
                                else
                                {
                                    goto answerCheck7;
                                }
                            }
                            else
                            {
                                goto answercheck6;
                            }
                        }
                        else
                        {
                            goto answerCheck5;
                        }
                    }
                    else
                    {
                        goto answerCheck4;
                    }
                }
                else
                {
                    goto answercheck3;
                }
            }
            else
            {
                goto answerCheck2;
            }
        }
        else
        {
            goto answerCheck1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //when all the questions are answerd
        if(question1answerd&&question2answerd&&question3answerd&&question4answerd)
        {
            /*
            print("you answerd " + answertoquestion1 + " on question 1");
            print("you answerd " + answertoquestion2 + " on question 2");
            print("you answerd " + answertoquestion3+ " on question 3");
            print("you answerd " + answertoquestion4+ " on question 4");
            */
            //if all answers are correct
            if (answertoquestion1==correctanswer1&&answertoquestion2==correctanswer2&&answertoquestion3==correctanswer3&&answertoquestion4==correctanswer4)
            {
                
                //tells the english task to compleat
                SendMessageUpwards("Englishtask_cleared", SendMessageOptions.RequireReceiver);
            }
            //if any answers are wrong
            else
            {
                //tells the english task to close
                print("ya failed");
              SendMessageUpwards("close_englishTask",SendMessageOptions.RequireReceiver);
            }
        }
    }
    //the functions called by the buttons please ignore
    public void Answer1()
    {
        if(!question1answerd)
        {
            print(answers[0].text);
            answertoquestion1 = answers[0].text;
            print(answertoquestion1+"tester1");
            
            question1answerd = true;
        }
    }
    public void Answer2()
    {
        if (!question1answerd)
        {
            print(answers[1].text);
            answertoquestion1 = answers[1].text;
            question1answerd = true;
        }
    }
    public void Answer3()
    {
        if (!question1answerd)
        {
            print(answers[2].text);
            answertoquestion1 = answers[2].text;
            question1answerd = true;
        }
    }
    public void Answer4()
    {
        if (!question1answerd)
        {
            print(answers[3].text);
            answertoquestion1 = answers[3].text;
            question1answerd = true;
        }
    }
    public void Answer5()
    {
        if (!question2answerd)
        {
            print(answers[4].text);
            answertoquestion2 = answers[4].text;
            question2answerd = true;
        }
    }
    public void Answer6()
    {
        if (!question2answerd)
        {
            print(answers[5].text);
            answertoquestion2 = answers[5].text;
            question2answerd = true;
        }
    }
    public void Answer7()
    {
        if (!question2answerd)
        {
            print(answers[6].text);
            answertoquestion2 = answers[6].text;
            question2answerd = true;
        }
    }
    public void Answer8()
    {
        if (!question2answerd)
        {
            print(answers[7].text);
            answertoquestion2 = answers[7].text;
            question2answerd = true;
        }
    }
    public void Answer9()
    {
        if (!question3answerd)
        {
            print(answers[8].text);
            answertoquestion3 = answers[8].text;
            question3answerd = true;
        }
    }
    public void Answer10()
    {
        if (!question3answerd)
        {
            print(answers[9].text);
            answertoquestion3 = answers[9].text;
            question3answerd = true;
        }
    }
    public void Answer11()
    {
        if (!question3answerd)
        {
            print(answers[10].text);
            answertoquestion3 = answers[10].text;
            question3answerd = true;
        }
    }
    public void Answer12()
    {
        if (!question3answerd)
        {
            print(answers[11].text);
            answertoquestion3 = answers[11].text;
            question3answerd = true;
        }
    }
    public void Answer13()
    {
        if (!question4answerd)
        {
            print(answers[12].text);
            answertoquestion4 = answers[12].text;
            question4answerd = true;
        }
    }
    public void Answer14()
    {
        if (!question4answerd)
        {
            print(answers[13].text);
            answertoquestion4 = answers[13].text;
            question4answerd = true;
        }
    }
    public void Answer15()
    {
        if (!question4answerd)
        {
            print(answers[14].text);
            answertoquestion4 = answers[14].text;
            question4answerd = true;
        }
    }
    public void Answer16()
    {
        if (!question4answerd)
        {
            print(answers[15].text);
            answertoquestion4 = answers[15].text;
            question4answerd = true;
        }
    }
    //turn of all the answer buttons
     void end_englishTask()
    {
        answers[0].text = "";
        answers[1].text = "";
        answers[2].text = "";
        answers[3].text = "";
        answers[4].text = "";
        answers[5].text = "";
        answers[6].text = "";
        answers[7].text = "";
        answers[8].text = "";
        answers[9].text = "";
        answers[10].text = "";
        answers[11].text = "";
        answers[12].text = "";
        answers[13].text = "";
        answers[14].text = "";
        answers[15].text = "";
        quest[0].text = "";
        quest[1].text = "";
        quest[2].text = "";
        quest[3].text = "";
        question1answerd = false;
        question2answerd = false;
        question3answerd = false;
        question4answerd = false;
    }
}
