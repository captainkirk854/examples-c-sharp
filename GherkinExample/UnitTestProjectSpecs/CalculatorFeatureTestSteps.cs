using System;
using TechTalk.SpecFlow;

namespace UnitTestProjectSpecs
{
    using TechTalk.SpecFlow;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyProjectFeatures;

    [Binding]
    public class CalculatorFeatureTestSteps
    {
        // Initialise class to be tested ..
        private Calculator calculator = new Calculator();

        private int result { get; set; }


        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            // ScenarioContext.Current.Pending();
            calculator.FirstNumber = number;
        }
        
        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            // ScenarioContext.Current.Pending();
            calculator.SecondNumber = number;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            // ScenarioContext.Current.Pending();
            result = calculator.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            //  ScenarioContext.Current.Pending();
            Assert.AreEqual(expectedResult, result);
        }
        
        [Then(@"the wrong result should be (.*) on the screen")]
        public void ThenTheWrongResultShouldBeOnTheScreen(int expectedResult)
        {
            //  ScenarioContext.Current.Pending();
            Assert.AreNotEqual(expectedResult, result);
        }
    }
}
