using System;
using System.Drawing;
using System.Linq;
using Utopia2._0.DAL.Models;
using Utopia2._0.DAL.Data;
using System.Collections.Generic;

namespace Utopia2._0.DAL
{
    public class DBInitializer
    {

        // Define the number of objects
        static int nrOfFaculties = 5;
        static int nrOfGraduatePrograms = 5;           // Per faculty
        static int nrOfQuestions = 10;                 // Per graduate program
        static int nrOfMultipleChoiceAnswers = 4;      // Per question
        static int nrOfPersons = 20;

        // Define the counters that start from zero
        static int facultyCounter = 0;
        static int graduateProgramCounter = 0;
        static int questionCounter = 0;
        static int multipleChoiceAnswerCounter = 0;
        // static int personCounter = 0;
        // static int answerCounter = 0;

        static Random rd = new Random();

        public static int GenerateRandomInt(int range) 
        {
            return rd.Next(1, range);
        }

        public static void Initialize(DataContext context)
        {
            
            context.Database.EnsureCreated();


            //// Loops to clear the context if necessary. Put these lines in comment if you do not want to delete the DataContext content.
            //foreach (var item in context.Faculties)
            //{
            //    context.Faculties.Remove(item);
            //}
            //context.SaveChanges();
            //foreach (var item in context.GraduatePrograms)
            //{
            //    context.GraduatePrograms.Remove(item);
            //}
            //context.SaveChanges();
            //foreach (var item in context.Questions)
            //{
            //    context.Questions.Remove(item);
            //}
            //context.SaveChanges();
            //foreach (var item in context.MultipleChoiceAnswers)
            //{
            //    context.MultipleChoiceAnswers.Remove(item);
            //}
            //context.SaveChanges();


            // If the context is empty, fill it up.
            if (!context.Faculties.Any())
            {
                // Add faculties
                for (int f = 1; f <= nrOfFaculties; f++)
                {
                    // Define the index of the faculty (might not match with the real index!)
                    facultyCounter++;
                    Faculty faculty = new Faculty { Name = "Faculty " + facultyCounter, Active = true };
                    context.Add(faculty);
                    context.SaveChanges();

                    // Add graduate programs
                    for (int g = 1; g <= nrOfGraduatePrograms; g++) 
                    {
                        // Define the index of the graduate program (might not match with the real index!)
                        graduateProgramCounter++;
                        GraduateProgram graduateProgram = new GraduateProgram { Name = "Graduate program " + graduateProgramCounter, Active = true, FacultyId = facultyCounter };
                        context.Add(graduateProgram);
                        context.SaveChanges();


                        // Add questions
                        for (int q = 1; q <= nrOfQuestions; q++)
                        {
                            // Define the index of the question (might not match with the real index!)
                            questionCounter++;
                            Question question = new Question { TextualQuestion = "This is a question? " + questionCounter, Active = true, GraduateProgramId = graduateProgramCounter };
                            context.Add(question);
                            context.SaveChanges();

                            var correctAnswerId = rd.Next(nrOfMultipleChoiceAnswers);


                            // Add multiple choice answers
                            for (int m = 1; m <= nrOfMultipleChoiceAnswers; m++)
                            {
                                // Check here if this answer is the correct one.
                                bool correct;
                                if (correctAnswerId == m)
                                {
                                    correct = true;
                                }
                                else
                                {
                                    correct = false;
                                }

                                // Define the index of the multiple choice answer (might not match with the real index!)
                                multipleChoiceAnswerCounter++;
                                MultipleChoiceAnswer multipleChoiceAnswer = new MultipleChoiceAnswer { TextualAnswer = "Multiple choice answer option " + multipleChoiceAnswerCounter, Active = true, Correct = correct, QuestionId = questionCounter };
                                context.Add(multipleChoiceAnswer);
                                context.SaveChanges();

                            }
                        }
                    }
                }   
            }
            

            // Add persons
            for (int p = 1; p <= nrOfPersons; p++)
            {
                // Define the index of the person (might not match with the real index!)
                // personCounter++;
                int randomNumber = rd.Next(1000000, 9999999);
                string random = randomNumber.ToString();
                Person person = new Person { Username = "Person " + p, Userkey = random };
                context.Add(person);
                context.SaveChanges();

                List<int> graduateProgramsDone = new List<int>();

                // Take a random number of graduate programs 
                var randomNumberOfGraduateProgramsToBeDone = rd.Next(nrOfFaculties * nrOfGraduatePrograms / 2);
                for (int g = 1; g <= randomNumberOfGraduateProgramsToBeDone; g++)
                {
                    // Define a random graduate program index
                    //int randomGraduateProgramId = rd.Next(1, nrOfFaculties * nrOfGraduatePrograms);
                    int randomGraduateProgramId = GenerateRandomInt(nrOfFaculties * nrOfGraduatePrograms);
                    var goon = false;
                    while (goon == false)
                    {

                        // Check if the ID is already done or not
                        if (graduateProgramsDone.Contains(randomGraduateProgramId) == true)
                        {
                            // This graduate program is already done. So we need to select another ID
                            randomGraduateProgramId = GenerateRandomInt(nrOfFaculties * nrOfGraduatePrograms);
                            goon = false;
                        }
                        else
                        {
                            // This graduate program is not done yet. So it is a valid choice.
                            graduateProgramsDone.Add(randomGraduateProgramId);
                            goon = true;
                        }
                    }

                    // Answer all the questions for that random graduate program
                    for (int q = 1; q <= nrOfQuestions; q++)
                    {

                        int startId = ((randomGraduateProgramId - 1) * nrOfQuestions * nrOfMultipleChoiceAnswers) + ((q - 1) * nrOfMultipleChoiceAnswers) + 1;
                        int finalId = startId + nrOfMultipleChoiceAnswers - 1;

                        Answer answer = new Answer { MultipleChoiceAnswerId = rd.Next(startId, finalId), PersonId = p, Date = DateTime.Parse("2022-09-01") };
                        context.Add(answer);
                        context.SaveChanges();

                    }
                }
            }

            context.SaveChanges();


        }
    }
}
