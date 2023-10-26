namespace Homework6._1;

public class Action
{
    Result result = new Result();
    Logger logger = new Logger();
    public Result InfoLog()
    {

        logger.CreateLog(0, "Start method: InfoLog");
        return new Result { Status = true };
    }
    public Result WarningLog()
    {
        logger.CreateLog(1, "Skipped logic in method: WarningLog");
        return new Result { Status = true };
    }
    public Result ErrorLog()
    {
        logger.CreateLog(2, "I broke a logic");
        return new Result { Status = false, ErrorMessage = "I broke a logic" };
    }
}

public class Result
{

    public bool Status { get; set; }
    public string? ErrorMessage { get; set; }

}

