//工厂的作用是根据点击的操作符来决定使用哪个类实例化接口
//工厂实现operInterfate()接口,实现的方法是用OperateAdd()等来实现

using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public  class OperateFactory
    {
        public OperateFactory()
        { 
            //TODO Counstruct Method
        }
        public OperateInterface CreateOperate(string strOperator)
        {
            if (strOperator.Equals("+"))
            {
                OperateInterface operInterf = new OperateAdd();                   //如果传进来的是+，定义一个接口operInterf，并且使用OperateAdd()来实例化这个接口
                //这时operInterf其实就是一个OperateAdd()的对象
                return operInterf;//这时把operInterf返回给operFac.CreateOperate(),再赋值给operInterface
            
            }

            else if (strOperator.Equals("-"))
            {
                OperateInterface operInterf = new OperateDec();
                return operInterf;

            }


            else if (strOperator.Equals("*"))
            {
                OperateInterface operInterf = new OperateRide();
                return operInterf;

            }

            else if(strOperator.Equals("/"))
            {
                OperateInterface operInterf = new OperateDiv();
                return operInterf;

            }

            else if (strOperator.Equals("reciprocal"))
            {
                OperateInterface operInterf = new OperateRecip();
                return operInterf;
            
            }
            return null;
            
        }



    }
}
