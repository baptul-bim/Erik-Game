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
        new string("syndrome"),
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
    new string("18answer1"),new string("18answer2"),new string("18answer3"),new string("18answer4"),
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
    private string answer1;
    private string answer2;
    private string answer3;
    private string answer4;
    private string answer5;
    private string answer6;
    private string answer7;
    private string answer8;
    private string answer9;
    private string answer10;
    private string answer11;
    private string answer12;
    private string answer13;
    private string answer14;
    private string answer15; 
    private string answer16;
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
        question1 = rng.Next(0, 21);
    questionCheck1:
        question2 = rng.Next(0, 21);
        if (question2 != question1)
        {
        questionCheck2:
            question3 = rng.Next(0, 21);
            if (question3 != question2 && question3 != question1)
            {
            questioncheck3:
                question4 = rng.Next(0, 21);
                if (question4 != question3 && question4 != question2 && question4 != question1)
                {
                    correctanswer1 = answer[question1*4];
                    correctanswer2 = answer[question2 * 4];
                    correctanswer3 = answer[question3 * 4];
                    correctanswer4 = answer[question4 * 4];
                    foreach(string i in  questions)
                    {
                        
                    }
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
       int answerslot1= rng.Next(0+question1, 4+question1);
    answerCheck1:
        int answerslot2 =rng.Next(0 + question1, 4 + question1);
        if(answerslot2!=answerslot1)
        {
        answerCheck2:
            int answerslot3 = rng.Next(0 + question1, 4 + question1);
            if(answerslot3!=answerslot1&&answerslot3!=answerslot2)
            {
            answercheck3:
                int answerslot4 = rng.Next(0 + question1, 4 + question1);
                if(answerslot4!=answerslot3&&answerslot4!=answerslot2&&answerslot4!=answerslot1)
                {
                    int answerslot12 = rng.Next(0 + question2, 4 + question2);
                answerCheck4:
                    int answerslot22 = rng.Next(0 + question2, 4 + question2);
                    if (answerslot22 != answerslot12)
                    {
                    answerCheck5:
                        int answerslot32 = rng.Next(0 + question2, 4 + question2);
                        if (answerslot32 != answerslot1 && answerslot3 != answerslot2)
                        {
                        answercheck6:
                            int answerslot42 = rng.Next(0 + question2, 4 + question2);
                            if (answerslot42 != answerslot3 && answerslot4 != answerslot2 && answerslot4 != answerslot1)
                            {
                                int answerslot13 = rng.Next(0 + question3, 4 + question3);
                            answerCheck7:
                                int answerslot23 = rng.Next(0 + question3, 4 + question3);
                                if (answerslot23 != answerslot13)
                                {
                                answerCheck8:
                                    int answerslot33 = rng.Next(0 + question3, 4 + question3);
                                    if (answerslot33 != answerslot13 && answerslot33 != answerslot23)
                                    {
                                    answercheck9:
                                        int answerslot43 = rng.Next(0 + question3, 4 + question3);
                                        if (answerslot43 != answerslot33 && answerslot43 != answerslot23 && answerslot13 != answerslot1)
                                        {
                                            int answerslot14 = rng.Next(0 + question4, 4 + question4);
                                        answerCheck10:
                                            int answerslot24 = rng.Next(0 + question4, 4 + question4);
                                            if (answerslot24 != answerslot14)
                                            {
                                            answerCheck11:
                                                int answerslot34 = rng.Next(0 + question4, 4 + question4);
                                                if (answerslot34 != answerslot14 && answerslot34 != answerslot24)
                                                {
                                                answercheck12:
                                                    int answerslot44 = rng.Next(0 + question4, 4 + question4);
                                                    if (answerslot44 != answerslot34 && answerslot44 != answerslot24 && answerslot44 != answerslot14)
                                                    {
                                                        answer1 = answer[answerslot1];
                                                        answer2 = answer[answerslot2];
                                                        answer3 = answer[answerslot3];
                                                        answer4 = answer[answerslot4];
                                                        answer5 = answer[answerslot12];
                                                        answer6 = answer[answerslot22];
                                                        answer7 = answer[answerslot32];
                                                        answer8 = answer[answerslot42];
                                                        answer9 = answer[answerslot13];
                                                        answer10 = answer[answerslot23];
                                                        answer11 = answer[answerslot33];
                                                        answer12 = answer[answerslot43];
                                                        answer13 = answer[answerslot14];
                                                        answer14 = answer[answerslot24];
                                                        answer15 = answer[answerslot34];
                                                        answer16 = answer[answerslot44];
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
            //if all answers are correct
            if(answertoquestion1==correctanswer1&&answertoquestion2==correctanswer2&&answertoquestion3==correctanswer3&&answertoquestion4==correctanswer4)
            {
                //tells the english task to compleat
                SendMessageUpwards("Englishtask_cleared",SendMessageOptions.RequireReceiver);
            }
            //if any answers are wrong
            else
            {
                //tells the english task to close
                SendMessageUpwards("close_englishTask",SendMessageOptions.RequireReceiver);
            }
        }
    }
    //the functions called by the buttons please ignore
    public void Answer1()
    {
        if(!question1answerd)
        {
            print(answer1);
            answertoquestion1 = answer1;
            question1answerd = true;
        }
    }
    public void Answer2()
    {
        if (!question1answerd)
        {
            print(answer2);
            answertoquestion1 = answer2;
            question1answerd = true;
        }
    }
    public void Answer3()
    {
        if (!question1answerd)
        {
            print(answer3);
            answertoquestion1 = answer3;
            question1answerd = true;
        }
    }
    public void Answer4()
    {
        if (!question1answerd)
        {
            print(answer4);
            answertoquestion1 = answer4;
            question1answerd = true;
        }
    }
    public void Answer5()
    {
        if (!question2answerd)
        {
            print(answer5);
            answertoquestion2 = answer5;
            question2answerd = true;
        }
    }
    public void Answer6()
    {
        if (!question2answerd)
        {
            print(answer6);
            answertoquestion2 = answer6;
            question2answerd = true;
        }
    }
    public void Answer7()
    {
        if (!question2answerd)
        {
            print(answer7);
            answertoquestion2 = answer7;
            question2answerd = true;
        }
    }
    public void Answer8()
    {
        if (!question2answerd)
        {
            print(answer8);
            answertoquestion2 = answer8;
            question2answerd = true;
        }
    }
    public void Answer9()
    {
        if (!question3answerd)
        {
            print(answer9);
            answertoquestion3 = answer9;
            question3answerd = true;
        }
    }
    public void Answer10()
    {
        if (!question3answerd)
        {
            print(answer10);
            answertoquestion3 = answer10;
            question3answerd = true;
        }
    }
    public void Answer11()
    {
        if (!question3answerd)
        {
            print(answer11);
            answertoquestion3 = answer11;
            question3answerd = true;
        }
    }
    public void Answer12()
    {
        if (!question3answerd)
        {
            print(answer12);
            answertoquestion3 = answer12;
            question3answerd = true;
        }
    }
    public void Answer13()
    {
        if (!question4answerd)
        {
            print(answer13);
            answertoquestion4 = answer13;
            question4answerd = true;
        }
    }
    public void Answer14()
    {
        if (!question4answerd)
        {
            print(answer14);
            answertoquestion4 = answer14;

            question4answerd = true;
        }
    }
    public void Answer15()
    {
        if (!question4answerd)
        {
            print(answer15);
            answertoquestion4 = answer15;
            question4answerd = true;
        }
    }
    public void Answer16()
    {
        if (!question4answerd)
        {
            print(answer16);
            answertoquestion4 = answer16;
            question4answerd = true;
        }
    }
    //turn of all the answer buttons
     void end_englishTask()
    {
        answers[0].enabled = false;
        answers[1].enabled = false;
        answers[2].enabled = false;
        answers[3].enabled = false;
        answers[4].enabled = false;
        answers[5].enabled = false;
        answers[6].enabled = false;
        answers[7].enabled = false;
        answers[8].enabled = false;
        answers[9].enabled = false;
        answers[10].enabled = false;
        answers[11].enabled = false;
        answers[12].enabled = false;
        answers[13].enabled = false;
        answers[14].enabled = false;
        answers[15].enabled = false;
    }
}
