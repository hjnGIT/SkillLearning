using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    #region ADD
    public class OperateAdd : OperateInterface                            //表明这个类是用来实现OperateInterface接口的
    {
        public OperateAdd()
        { 
            // TODO:Construct Metod
        }

        public object Operate(object oNum1,object oNum2)
        {
            decimal Num1 = decimal.Parse(oNum1.ToString());
            decimal Num2 = decimal.Parse(oNum2.ToString());
            return Num2 + Num1;

        }
    }
    #endregion

    #region Dec
    public class OperateDec : OperateInterface
    {
        public OperateDec()
        {
            // TODO:Construct Metod
        }

        public object Operate(object oNum1, object oNum2)
        {
            decimal Num1 = decimal.Parse(oNum1.ToString());
            decimal Num2 = decimal.Parse(oNum2.ToString());
            return Num2 - Num1;
        }
    }
    #endregion

    #region Ride
    public class OperateRide : OperateInterface
    {
        public OperateRide()
        {
            // TODO:Construct Metod
        }

        public object Operate(object oNum1, object oNum2)
        {
            decimal Num1 = decimal.Parse(oNum1.ToString());
            decimal Num2 = decimal.Parse(oNum2.ToString());
            return Num2 * Num1;
        }
    }
    #endregion endRide

    #region Div
    public class OperateDiv : OperateInterface
    {
        public OperateDiv()
        {
            // TODO:Construct Metod
        }

        public object Operate(object oNum1, object oNum2)
        {
            decimal Num1 = decimal.Parse(oNum1.ToString());
            decimal Num2 = decimal.Parse(oNum2.ToString());

            
            return  Num2 / Num1;
        }
    }
    #endregion

    #region reciprocal
    public class OperateRecip : OperateInterface
    { 
        public OperateRecip()
        {
           // TODO:Construct Metod 
        }
        public object Operate(object oNum1,object oNum2 )
        {
            decimal Num1 = decimal.Parse(oNum1.ToString());
            decimal Num2 = decimal.Parse(oNum2.ToString());
            return 1 / Num1;
        
        }
    
    }
    #endregion Ends_reciprocal
}


