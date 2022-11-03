using System;

namespace PL
{
    public class MainMenu
    {
        private TestMenu testMenu = new TestMenu();
        private QuestionMenu questionMenu = new QuestionMenu();
        private AnswerMenu answerMenu = new AnswerMenu();
        public void Help()
        {
            Console.WriteLine("Команди, які ви можете використати:");
            Console.WriteLine("1. /help - виводить команди, які можуть використовуватися у програмі;");
            Console.WriteLine("2. /add - додати новий(-і) елементи у БД;");
            Console.WriteLine("3. /delete - видалити елемент з БД;");
            Console.WriteLine("4. /show - вивести дані в БД у вигляді таблиці;");
            Console.WriteLine("5. /search - знайти елемент в БД");
            Console.WriteLine("6. /update - Оновити елемент(-и) в БД");
            Console.WriteLine("7. /start - Розпочати тестування");
            Console.WriteLine("8. /statistic - Переглянути статистику тестів");
            Console.WriteLine("9. /end - закінчити роботу з БД.");
        }
        public void UnhandledCommand()
        {
            Console.WriteLine("Такої команди не існує! Спробуйте ввети іншу з переліку.");
            Help();
        }

        public void AddEntity()  //Help 2
        {
            try {
                int option = 0;
                Console.WriteLine("З якою сутністю Ви хочете працювати?: ");
                Console.WriteLine("1. Тести");
                Console.WriteLine("2. Питання");
                Console.WriteLine("3. Відповіді");
                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        testMenu.AddTest();
                        return;
                    case 2:
                       questionMenu.AddQuestion();
                        return;
                    case 3:
                       answerMenu.AddAnswer();
                        return;
                    default:
                        throw new Exception("Виберіть коректний номер сутності");
                }

            }
            catch (FormatException ex)
            {
                Console.WriteLine();
                Console.WriteLine("Некоректний ввід даних, наступного разу введіть, будь ласка, число!");
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Виникла помилка:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
         }
        public void RemoveEntity()  //delete 3
        {
            try
            {
                int option = 0;
                Console.WriteLine("З якою сутністю Ви хочете працювати?: ");
                Console.WriteLine("1. Тести");
                Console.WriteLine("2. Питання");
                Console.WriteLine("3. Відповіді");
                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        testMenu.RemoveTest();
                        return;
                    case 2:
                        questionMenu.RemoveQuestion();
                        return;
                    case 3:
                        answerMenu.RemoveAnswer();
                        return;
                    default:
                        throw new Exception("Виберіть коректний номер сутності");
                }

            }catch (FormatException ex)
            {
                Console.WriteLine();
                Console.WriteLine("Некоректний ввід даних, наступного разу введіть, будь ласка, число!");
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Виникла помилка:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
        }

        public void ShowEntity()  //show 4
        {
            try
            {
                int option = 0;
                Console.WriteLine("З якою сутністю Ви хочете працювати?: ");
                Console.WriteLine("1. Тести");
                Console.WriteLine("2. Питання");
                Console.WriteLine("3. Відповіді");
                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        testMenu.GetAllTest();
                        return;
                    case 2:
                        questionMenu.GetAllQuestions();
                        return;
                    case 3:
                        answerMenu.GetAllAnswers();
                        return;
                    default:
                        throw new Exception("Виберіть коректний номер сутності");
                }

            }catch (FormatException ex)
            {
                Console.WriteLine();
                Console.WriteLine("Некоректний ввід даних, наступного разу введіть, будь ласка, число!");
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Виникла помилка:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
        }

        public void SearchEntity()//search 5
        {
            try
            {
                int option = 0;
                Console.WriteLine("З якою сутністю Ви хочете працювати?: ");
                Console.WriteLine("1. Тести");
                Console.WriteLine("2. Питання");
                Console.WriteLine("3. Відповіді");
                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        testMenu.GetTest();
                        return;
                    case 2:
                        questionMenu.GetQuestion();
                        return;
                    case 3:
                        answerMenu.GetAnswer();
                        return;
                    default:
                        throw new Exception("Виберіть коректний номер сутності");
                }

            }catch (FormatException ex)
            {
                Console.WriteLine();
                Console.WriteLine("Некоректний ввід даних, наступного разу введіть, будь ласка, число!");
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Виникла помилка:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
        }

        public void UpdateEntity()  //update 6
        {
            try
            {
                int option = 0;
                Console.WriteLine("З якою сутністю Ви хочете працювати?: ");
                Console.WriteLine("1. Тести");
                Console.WriteLine("2. Питання");
                Console.WriteLine("3. Відповіді");
                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        UpdateForTest();
                        return;
                    case 2:
                        questionMenu.UpdateQuestion();
                        return;
                    case 3:
                        answerMenu.UpdateAnswer();
                        return;
                    default:
                        throw new Exception("Виберіть коректний номер сутності");
                }

            }
            catch (FormatException ex)
            {
                Console.WriteLine();
                Console.WriteLine("Некоректний ввід даних, наступного разу введіть, будь ласка, число!");
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Виникла помилка:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
        }

        public void StartTest()
        {
            try
            {
                testMenu.StartTheTest();
            }catch(Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Виникла помилка:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
        }

        private void UpdateForTest()
        {
            try
            {
                int option = 0;
                Console.WriteLine("Що саме ви бажаєте оновити в тесті?: ");
                Console.WriteLine("1. Ім'я тесту");
                Console.WriteLine("2. К-сть питань в тесті");
                Console.WriteLine("3. Час на 1 питання в тесті");
                option = Int32.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        testMenu.UpdateTestName();
                        return;
                    case 2:
                        testMenu.UpdateNumberOfQuestions();
                        return;
                    case 3:
                        testMenu.UpdateTimeForQuestion();
                        return;
                    default:
                        throw new Exception("Виберіть коректний номер сутності");
                }
            }catch (FormatException ex)
            {
                Console.WriteLine();
                Console.WriteLine("Некоректний ввід даних, наступного разу введіть, будь ласка, число!");
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Виникла помилка:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Спробуйте ще раз, ввівши коректні дані");
                Console.WriteLine();
                Help();
            }
        }
        public void Start()
        {
            string input = "";
            Help();
            do
            {
                input = Console.ReadLine().Trim();

                if (input == "1")
                {
                    Help();
                }
                else if (input == "2")
                {
                    AddEntity();
                }
                else if (input == "3")
                {
                    RemoveEntity();
                }
                else if (input == "4")
                {
                    ShowEntity();
                }
                else if (input == "5")
                {
                    SearchEntity();
                }
                else if (input == "6")
                {
                    UpdateEntity();
                }
                else if (input == "7")
                {
                    StartTest();
                }
                else if (input == "8")
                {
                    testMenu.TestStatisicOutput();
                }
                else if(input == "9")
                {
                    Console.WriteLine("Завершуємо роботу...");
                    break;
                }
                else
                {
                    UnhandledCommand();
                }
            } while (input != "9");

            input = Console.ReadLine();
        }
    }
}
