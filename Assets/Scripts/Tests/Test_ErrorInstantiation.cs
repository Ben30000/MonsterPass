using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class Test_ErrorInstantiation
    {
        [SetUp]
        public void SetScene()
        {
            SceneManager.LoadScene("titleScreen");
        }

        [UnityTest]
        public IEnumerator Test_Signin_Empty()
        {          
            Button login = GameObject.Find("loginButton").GetComponent<Button>();
            login.onClick.Invoke();

            yield return null;

            Button signin = GameObject.Find("signInButton").GetComponent<Button>();
            signin.onClick.Invoke();

            yield return null;

            var errorPrefab = GameObject.Find("ErrorOverlay(Clone)");
            Assert.IsNotNull(errorPrefab);
        }

        [UnityTest]
        public IEnumerator Test_Signin_NotRegistered()
        {          
            Button login = GameObject.Find("loginButton").GetComponent<Button>();
            login.onClick.Invoke();

            yield return null;

            InputField username = GameObject.Find("usernameInput").GetComponent<InputField>();
            InputField password = GameObject.Find("passwordInput").GetComponent<InputField>();
            username.text = "notregistered";
            password.text = "password";
            Button signin = GameObject.Find("signInButton").GetComponent<Button>();
            signin.onClick.Invoke();

            yield return new WaitForSeconds(2);

            var errorPrefab = GameObject.Find("ErrorOverlay(Clone)");
            Assert.IsNotNull(errorPrefab);
        }

        [UnityTest]
        public IEnumerator Test_Signin_Incorrect()
        {          
            Button login = GameObject.Find("loginButton").GetComponent<Button>();
            login.onClick.Invoke();

            yield return null;

            InputField username = GameObject.Find("usernameInput").GetComponent<InputField>();
            InputField password = GameObject.Find("passwordInput").GetComponent<InputField>();
            username.text = "test_1";
            password.text = "notpassword";
            Button signin = GameObject.Find("signInButton").GetComponent<Button>();
            signin.onClick.Invoke();

            yield return new WaitForSeconds(2);

            var errorPrefab = GameObject.Find("ErrorOverlay(Clone)");
            Assert.IsNotNull(errorPrefab);
        }

        [UnityTest]
        public IEnumerator Test_Register_Empty()
        {
            Button register = GameObject.Find("registerButton").GetComponent<Button>();
            register.onClick.Invoke();

            yield return null;

            register = GameObject.Find("registerButton").GetComponent<Button>();
            register.onClick.Invoke();

            yield return null;

            var errorPrefab = GameObject.Find("ErrorOverlay(Clone)");
            Assert.IsNotNull(errorPrefab);
        }

        [UnityTest]
        public IEnumerator Test_Register_Mismatch()
        {
            Button register = GameObject.Find("registerButton").GetComponent<Button>();
            register.onClick.Invoke();

            yield return null;

            InputField username = GameObject.Find("usernameInput").GetComponent<InputField>();
            InputField emailInput = GameObject.Find("emailInput").GetComponent<InputField>();
            InputField passInput1 = GameObject.Find("passInput1").GetComponent<InputField>();
            InputField passInput2 = GameObject.Find("passInput2").GetComponent<InputField>();

            username.text = "test_1";
            emailInput.text = "rand@gmail.com";
            passInput1.text = "firstpass";
            passInput2.text = "secondpass";

            register = GameObject.Find("registerButton").GetComponent<Button>();
            register.onClick.Invoke();

            yield return null;

            var errorPrefab = GameObject.Find("ErrorOverlay(Clone)");
            Assert.IsNotNull(errorPrefab);
        }

        [UnityTest]
        public IEnumerator Test_Register_Duplicate()
        {
            Button register = GameObject.Find("registerButton").GetComponent<Button>();
            register.onClick.Invoke();

            yield return null;

            InputField username = GameObject.Find("usernameInput").GetComponent<InputField>();
            InputField emailInput = GameObject.Find("emailInput").GetComponent<InputField>();
            InputField passInput1 = GameObject.Find("passInput1").GetComponent<InputField>();
            InputField passInput2 = GameObject.Find("passInput2").GetComponent<InputField>();

            username.text = "test_1";
            emailInput.text = "rand@gmail.com";
            passInput1.text = "pass";
            passInput2.text = "pass";

            register = GameObject.Find("registerButton").GetComponent<Button>();
            register.onClick.Invoke();

            yield return new WaitForSeconds(2);

            var errorPrefab = GameObject.Find("ErrorOverlay(Clone)");
            Assert.IsNotNull(errorPrefab);
        }
    }
}
