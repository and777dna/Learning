namespace LearningConsoleProject;

public static class InputValidator//LearningConsoleProject.InputValidator
{
    /*int Read()
    {
        string numberInputContinue = Console.ReadLine();
        Validate(numberInputContinue);
    }*/
    public static int Validate(string numberInput)
    {
        int myNumber;
        //string numberInputContinue = Console.ReadLine();    
        if (!String.IsNullOrEmpty(numberInput))
        {
            myNumber = Int32.Parse(numberInput);
        }
        else
        {
            throw new ArgumentException("Parameter cannot be null");
        }

        return myNumber;
    }
    
}