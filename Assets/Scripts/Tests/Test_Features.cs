using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class Test_Features
    {
        [SetUp]
        public void SetScene()
        {
            SceneManager.LoadScene("titleScreen");
        }

        [UnityTest]
        public IEnumerator Test_Transition()
        {
            Button login = GameObject.Find("loginButton").GetComponent<Button>();
            login.onClick.Invoke();

            yield return null;

            Assert.AreEqual("signinScreen",SceneManager.GetActiveScene().name);
            Button back = GameObject.Find("backButton").GetComponent<Button>();
            back.onClick.Invoke();

            yield return null;

            Assert.AreEqual("titleScreen",SceneManager.GetActiveScene().name);
            Button register = GameObject.Find("registerButton").GetComponent<Button>();
            register.onClick.Invoke();

            yield return null;

            Assert.AreEqual("registerScreen",SceneManager.GetActiveScene().name);
            back = GameObject.Find("backButton").GetComponent<Button>();
            back.onClick.Invoke();

            yield return null;

            Assert.AreEqual("titleScreen",SceneManager.GetActiveScene().name);
            login = GameObject.Find("loginButton").GetComponent<Button>();
            login.onClick.Invoke();

            yield return null;

            InputField username = GameObject.Find("usernameInput").GetComponent<InputField>();
            InputField password = GameObject.Find("passwordInput").GetComponent<InputField>();
            username.text = "test_1";
            password.text = "password";
            Button signin = GameObject.Find("signInButton").GetComponent<Button>();
            signin.onClick.Invoke();

            yield return new WaitForSeconds(2);

            Assert.AreEqual("ranchScreen",SceneManager.GetActiveScene().name);
            Button settings = GameObject.Find("SettingsIcon").GetComponent<Button>();
            settings.onClick.Invoke();

            yield return null;

            Assert.AreEqual("settingsScreen",SceneManager.GetActiveScene().name);
            back = GameObject.Find("backButton").GetComponent<Button>();
            back.onClick.Invoke();
            
            yield return null;

            Assert.AreEqual("ranchScreen",SceneManager.GetActiveScene().name);
            Button edit = GameObject.Find("monsterButton").GetComponent<Button>();
            edit.onClick.Invoke();

            yield return null;

            Assert.AreEqual("monsterEditingScreen",SceneManager.GetActiveScene().name);
            back = GameObject.Find("backButton").GetComponent<Button>();
            back.onClick.Invoke();
            
            yield return null;

            Assert.AreEqual("ranchScreen",SceneManager.GetActiveScene().name);
            settings = GameObject.Find("SettingsIcon").GetComponent<Button>();
            settings.onClick.Invoke();

            yield return null;

            Button logout = GameObject.Find("Logout").GetComponent<Button>();
            logout.onClick.Invoke();

            yield return null;

            Assert.AreEqual("titleScreen",SceneManager.GetActiveScene().name);
        }

        [UnityTest]
        public IEnumerator Test_Register_Clear()
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

            Button clear = GameObject.Find("clearButton").GetComponent<Button>();
            clear.onClick.Invoke();

            yield return null;

            Assert.AreEqual("", username.text);
            Assert.AreEqual("", emailInput.text);
            Assert.AreEqual("", passInput1.text);
            Assert.AreEqual("", passInput2.text);
        }

        [UnityTest]
        public IEnumerator Test_SettingsOverlay()
        {
            Button login = GameObject.Find("loginButton").GetComponent<Button>();
            login.onClick.Invoke();

            yield return null;

            InputField username = GameObject.Find("usernameInput").GetComponent<InputField>();
            InputField password = GameObject.Find("passwordInput").GetComponent<InputField>();
            username.text = "test_1";
            password.text = "password";
            login = GameObject.Find("signInButton").GetComponent<Button>();
            login.onClick.Invoke();

            yield return null;

            Button slider = GameObject.Find("SettingsSlider").GetComponent<Button>();
            slider.onClick.Invoke();

            yield return new WaitForSeconds(2);

            GameObject overlay = GameObject.Find("SettingsOverlay");
            GameObject position = GameObject.Find("SettingsMenuOpen");
            Assert.AreEqual(position.transform, overlay.transform);

            slider.onClick.Invoke();

            yield return new WaitForSeconds(2);

            position = GameObject.Find("SettingsMenuClose");
            Assert.AreEqual(position.transform, overlay.transform);
        }

        [UnityTest]
        public IEnumerator Test_NotificationOverlay()
        {
            Button login = GameObject.Find("loginButton").GetComponent<Button>();
            login.onClick.Invoke();

            yield return null;

            InputField username = GameObject.Find("usernameInput").GetComponent<InputField>();
            InputField password = GameObject.Find("passwordInput").GetComponent<InputField>();
            username.text = "test_1";
            password.text = "password";
            login = GameObject.Find("signInButton").GetComponent<Button>();
            login.onClick.Invoke();

            yield return null;

            Button slider = GameObject.Find("NotificationSlider").GetComponent<Button>();
            slider.onClick.Invoke();

            yield return new WaitForSeconds(2);

            GameObject overlay = GameObject.Find("NotificationOverlay");
            GameObject position = GameObject.Find("NotificationOpen");
            Assert.AreEqual(position.transform, overlay.transform);

            slider.onClick.Invoke();

            yield return new WaitForSeconds(2);

            position = GameObject.Find("NotificationClose");
            Assert.AreEqual(position.transform, overlay.transform);
        }

        [UnityTest]
        public IEnumerator Test_ReceivedDisplay()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_MatrixScroll()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_MusicToggle()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_ChangeSettings()
        {
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator Test_UpdatePreference()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_TabNavigation()
        {
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator Test_TabBodyColor()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_TabEarShape()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_TabTailShape()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_TabEyesColor()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_TabEyesShape()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_TabHornColor()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_TabHornShape()
        {
            yield return null;
        }
    }
}
