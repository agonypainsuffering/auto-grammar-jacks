using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

/// <summary>
/// This program is partly done in Finnish and partly in English
/// Sorry, it might be a bit hard to understand as this was a quick project
/// Hannulle terkkuja 👋
/// </summary>

namespace AutoJack
{
    public partial class AutoJack : Form
    {
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static IntPtr gameWindow(string windowName)
        {
            var x = FindWindow(null, windowName);
            return x;
        }

        Size form_up = new Size(387, 185);
        Size form_down = new Size(387, 469);

        private KeyHandler ghk;
        Random rand = new Random();
        Keyboard k = new Keyboard();

        string softan_nimi = "AutoJack";
        string softan_versio = "1.3 Alpha";
        
        string[] tilat = { "Running", "Stopped", "Stopping...", "Finished!", "Ready to start (F8)" };

        string openchatkey = "/";
        bool jump = true;

        int count_to = 100;
        int continue_from = 1;

        int speed = 50;

        bool sanoina = false;
        bool hell = false;
        bool number = true;
        bool death = false;

        bool caps = false;
        bool begin_caps = false;
        bool fullstop = false;
        bool hyphen = false;

        public AutoJack()
        {
            InitializeComponent();

            ghk = new KeyHandler(Keys.F8, this);
            ghk.Register();

            this.Text = softan_nimi + " V" + softan_versio;

            AutoJack.ActiveForm.Size = form_down;
            upButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            refreshProcesses.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            LoadProcesses();
        }

        bool jatka = true;
        bool stop = false;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                if (!stop)
                {
                    stop = true;
                    animaatio();
                }
                else
                {
                    tila.Text = tilat[2];
                    tila.ForeColor = Color.Orange;
                    jatka = false;
                    stop = false;
                }
            }

            base.WndProc(ref m);
        }

        double r_venaus = 0;
        int odotus = 0;
        string message = "";

        int odotus_funktio()
        {
            r_venaus = message.Length + 1;
            r_venaus = Math.Pow(r_venaus, 2);
            r_venaus = r_venaus * speed/2;
            r_venaus = Math.Floor(r_venaus);
            odotus = Convert.ToInt32(r_venaus.ToString());
            odotus = odotus / 2;
            odotus = rand.Next(odotus, odotus * 2);
            currentWait.Text = string.Format("Current typing wait: {0} ms",odotus.ToString());
            return odotus;
        }

        void active()
        {
            if(processBox.Text.Length > 0)
            SetForegroundWindow(gameWindow(processBox.Text));
        }

        private void LoadProcesses()
        {
            processBox.Items.Clear();
            Process[] Proc = Process.GetProcesses();
            foreach (Process process in Proc)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    processBox.Items.Add(process.MainWindowTitle);
                }
            }
        }

        async void animaatio()
        {
            //Informoi käyttäjälle loopin status (Aloitettu)
            tila.Text = tilat[0];
            tila.ForeColor = Color.Green;

            for (int i = continue_from; i <= count_to; i++)
            {
                if (i == count_to)
                    jatka = false;
                else 
                    startFromUpDown.Value = i + 1;

                await Task.Delay(rand.Next(100, 500));

                if (sanoina)
                {
                    /// SANA MOODI - NUMEROT OVAT SANOINA
                    /////////////////////////////////////

                    //Tuo ikkuna esille
                    active();

                    //Avaa chatti
                    SendKeys.Send(openchatkey);

                    //Muunna numero sanoiksi
                    message = NumberToWords(i);

                    //Kaikki kirjaimet isolla
                    if (caps) message = message.ToUpper();

                    //Iso alkukirjain
                    if (begin_caps) message = FirstCharToUpper(message);

                    //Lisää piste loppuun
                    if (fullstop) message += ".";

                    currentNumber.Text = string.Format("Currently typing: \"{0}\"", message);

                    //Laske realistinen odotusaika ja odota
                    await Task.Delay(odotus_funktio());

                    //Tuo ikkuna esille
                    active();

                    //Kirjoita viesti
                    SendKeys.Send(message);

                    //Tuo ikkuna esille
                    active();

                    //Lähetä viesti
                    k.Send(Keyboard.ScanCodeShort.RETURN, true);
                    k.Send(Keyboard.ScanCodeShort.RETURN, false);
                }
                else if (hell)
                {
                    /// HELVETTI MOODI - KIRJAIMET JA SANAT
                    ///////////////////////////////////////

                    //Muunna numero sanoiksi
                    message = NumberToWords(i);

                    //Kaikki kirjaimet isolla
                    if (caps) message = message.ToUpper();

                    //Iso alkukirjain
                    if (begin_caps) message = FirstCharToUpper(message);

                    //Tallenna koko sana muistiin
                    string full_message = message;

                    //Poista kaikki välilyönnit
                    message = message.Replace(" ", string.Empty);

                    char[] arr = message.ToCharArray();
                    foreach (char ch in arr)
                    {
                        //Tuo ikkuna esille
                        active();

                        //Avaa chatti
                        SendKeys.Send(openchatkey);

                        //Lisää piste loppuun
                        string chr = ch.ToString();
                        if (fullstop) chr += ".";

                        currentNumber.Text = string.Format("Currently typing: \"{0}\"", chr);

                        //Laske realistinen odotusaika ja odota
                        await Task.Delay(odotus_funktio());

                        //Tuo ikkuna esille
                        active();

                        //Kirjoita kirjain/viesti
                        SendKeys.Send(chr);

                        //Tuo ikkuna esille
                        active();

                        //Lähetä viesti
                        k.Send(Keyboard.ScanCodeShort.RETURN, true);
                        k.Send(Keyboard.ScanCodeShort.RETURN, false);

                        //Hyppää
                        if (jump)
                        {
                            await Task.Delay(rand.Next(250, 1000));
                            k.Send(Keyboard.ScanCodeShort.SPACE, true);
                            await Task.Delay(rand.Next(50, 100));
                            k.Send(Keyboard.ScanCodeShort.SPACE, false);
                        }
                    }

                    //Tuo ikkuna esille
                    active();

                    //Avaa chatti
                    SendKeys.Send(openchatkey);

                    //Lisää piste loppuun
                    if (fullstop) full_message += ".";

                    currentNumber.Text = string.Format("Currently typing: \"{0}\"", full_message);

                    //Laske realistinen odotusaika ja odota
                    await Task.Delay(odotus_funktio());

                    //Tuo ikkuna esille
                    active();

                    SendKeys.Send(full_message);

                    //Tuo ikkuna esille
                    active();

                    //Lähetä viesti
                    k.Send(Keyboard.ScanCodeShort.RETURN, true);
                    k.Send(Keyboard.ScanCodeShort.RETURN, false);
                }
                else if (death)
                {
                    /// DEATH MOODI - KIRJAIMET JA SANAT VÄÄRINPÄIN
                    ///////////////////////////////////////////////

                    //Muunna numero sanoiksi
                    message = NumberToWords(i);

                    //Kaikki kirjaimet isolla
                    if (caps) message = message.ToUpper();

                    //Iso alkukirjain
                    if (begin_caps) message = FirstCharToUpper(message);

                    //Käännä sana toisinpäin
                    message = Reverse(message);

                    //Tallenna koko sana muistiin
                    string full_message = message;

                    //Poista kaikki välilyönnit
                    message = message.Replace(" ", string.Empty);

                    char[] arr = message.ToCharArray();
                    foreach (char ch in arr)
                    {
                        //Tuo ikkuna esille
                        active();

                        //Avaa chatti
                        SendKeys.Send(openchatkey);

                        //Lisää piste loppuun
                        string chr = ch.ToString();
                        if (fullstop) chr += ".";

                        currentNumber.Text = string.Format("Currently typing: \"{0}\"", chr);

                        //Laske realistinen odotusaika ja odota
                        await Task.Delay(odotus_funktio());

                        //Tuo ikkuna esille
                        active();

                        //Kirjoita kirjain/viesti
                        SendKeys.Send(chr);

                        //Tuo ikkuna esille
                        active();

                        //Lähetä viesti
                        k.Send(Keyboard.ScanCodeShort.RETURN, true);
                        k.Send(Keyboard.ScanCodeShort.RETURN, false);

                        //Hyppää
                        if (jump)
                        {
                            await Task.Delay(rand.Next(250, 1000));
                            k.Send(Keyboard.ScanCodeShort.SPACE, true);
                            await Task.Delay(rand.Next(50, 100));
                            k.Send(Keyboard.ScanCodeShort.SPACE, false);
                        }
                    }

                    //Tuo ikkuna esille
                    active();

                    //Avaa chatti
                    SendKeys.Send(openchatkey);

                    //Lisää piste loppuun
                    if (fullstop) full_message += ".";

                    currentNumber.Text = string.Format("Currently typing: \"{0}\"", full_message);

                    //Laske realistinen odotusaika ja odota
                    await Task.Delay(odotus_funktio());

                    //Tuo ikkuna esille
                    active();

                    SendKeys.Send(full_message);

                    //Tuo ikkuna esille
                    active();

                    //Lähetä viesti
                    k.Send(Keyboard.ScanCodeShort.RETURN, true);
                    k.Send(Keyboard.ScanCodeShort.RETURN, false);
                }
                else if (number)
                {
                    /// NORMAALI MOODI - NUMEROT
                    ////////////////////////////

                    //Tuo ikkuna esille
                    active();

                    //Avaa chatti
                    SendKeys.Send(openchatkey);

                    //Viesti on numero, suoraan loopista
                    message = i.ToString();

                    //Lisää piste loppuun
                    if (fullstop) message += ".";

                    currentNumber.Text = string.Format("Currently typing: \"{0}\"", message);

                    //Laske realistinen odotusaika ja odota
                    await Task.Delay(odotus_funktio());

                    //Tuo ikkuna esille
                    active();

                    //Kirjoita viesti
                    SendKeys.Send(message);

                    //Tuo ikkuna esille
                    active();

                    //Lähetä viesti
                    k.Send(Keyboard.ScanCodeShort.RETURN, true);
                    k.Send(Keyboard.ScanCodeShort.RETURN, false);
                } 

                //Hyppää
                if (jump)
                {
                    await Task.Delay(rand.Next(500, 1000));
                    k.Send(Keyboard.ScanCodeShort.SPACE,true);
                    await Task.Delay(rand.Next(50, 100));
                    k.Send(Keyboard.ScanCodeShort.SPACE, false);
                }

                if (!jatka)
                {
                    if (i != count_to)
                    {
                        //Stop execution
                        ////////////////

                        currentWait.Text = "Current typing wait: None";
                        currentNumber.Text = "Currently typing: None";
                        tila.Text = tilat[1];
                        tila.ForeColor = Color.Red;
                        await Task.Delay(1000);
                        tila.Text = tilat[4];
                        tila.ForeColor = Color.Black;
                    }
                    else
                    {
                        //Finished jumping
                        //////////////////

                        currentWait.Text = "Current typing wait: None";
                        currentNumber.Text = "Currently typing: None";
                        startFromUpDown.Value = 1;
                        continue_from = 1;
                        stop = false;
                        tila.Text = tilat[3];
                        tila.ForeColor = Color.Green;
                        await Task.Delay(1000);
                        tila.Text = tilat[4];
                        tila.ForeColor = Color.Black;
                    }
                    break;
                }
            }
            jatka = true;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }

        public string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                    if (!hyphen) words += " " + unitsMap[number % 10];
                    else words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public string DecimalToWords(decimal number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + DecimalToWords(Math.Abs(number));

            string words = "";

            int intPortion = (int)number;
            decimal fraction = (number - intPortion) * 100;
            int decPortion = (int)fraction;

            words = NumberToWords(intPortion);
            if (decPortion > 0)
            {
                words += " and ";
                words += NumberToWords(decPortion);
            }
            return words;
        }

        //////////////////////////////////////////////////////////////////////////

        private void sanoinaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sanoina = sanoinaCheckBox.Checked;
            if (sanoina)
            {
                hellCheckBox.Checked = false;
                numbermodeCheckBox.Checked = false;
                deathCheckBox.Checked = false;
            }
        }

        private void hellCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hell = hellCheckBox.Checked;
            if (hell)
            {
                sanoinaCheckBox.Checked = false;
                numbermodeCheckBox.Checked = false;
                deathCheckBox.Checked = false;
            }
        }

        private void startFromUpDown_ValueChanged(object sender, EventArgs e)
        {
            continue_from = Decimal.ToInt32(startFromUpDown.Value);
        }

        private void countToUpDown_ValueChanged(object sender, EventArgs e)
        {
            count_to = Decimal.ToInt32(countToUpDown.Value);
        }

        private void jumpBetween_CheckedChanged(object sender, EventArgs e)
        {
            jump = jumpBetween.Checked;
        }

        private void openchatTextBox_TextChanged(object sender, EventArgs e)
        {
            if(openchatTextBox.Text.Length == 1) openchatkey = openchatTextBox.Text;
        }

        private void speedBar_ValueChanged(object sender, EventArgs e)
        {
            speed = speedBar.Value;
            speedLabel.Text = "Delay (" + speed.ToString() + ")";
        }

        private void hyphenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hyphen = hyphenCheckBox.Checked;
        }

        private void begincapitalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            begin_caps = begincapitalCheckBox.Checked;
        }

        private void capsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            caps = hellCapsCheckBox.Checked;
        }

        private void fullstopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fullstop = fullstopCheckBox.Checked;
        }

        private void numbermodeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            number = numbermodeCheckBox.Checked;
            if (number)
            {
                hellCheckBox.Checked = false;
                sanoinaCheckBox.Checked = false;
                deathCheckBox.Checked = false;
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (AutoJack.ActiveForm.Size == form_up)
            {
                AutoJack.ActiveForm.Size = form_down;
                upButton.Text = "🡱";
            }
            else if (AutoJack.ActiveForm.Size == form_down)
            {
                AutoJack.ActiveForm.Size = form_up;
                upButton.Text = "🡳";
            } 
        }

        private void keybindBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tila.Focus();
            Keys startbutton = new Keys();

            switch (keybindBox.Text)
            {
                case "F1":
                    startbutton = Keys.F1;
                    break;
                case "F2":
                    startbutton = Keys.F2;
                    break;
                case "F3":
                    startbutton = Keys.F3;
                    break;
                case "F4":
                    startbutton = Keys.F4;
                    break;
                case "F5":
                    startbutton = Keys.F5;
                    break;
                case "F6":
                    startbutton = Keys.F6;
                    break;
                case "F7":
                    startbutton = Keys.F7;
                    break;
                case "F8":
                    startbutton = Keys.F8;
                    break;
                case "F9":
                    startbutton = Keys.F9;
                    break;
                case "F10":
                    startbutton = Keys.F10;
                    break;
                case "F11":
                    startbutton = Keys.F11;
                    break;
                case "F12":
                    startbutton = Keys.F12;
                    break;
            }

            ghk = new KeyHandler(startbutton, this);
            ghk.Register();

            tilat[4] = "Ready to start (" + startbutton.ToString() + ")";
            tila.Text = tilat[4];
        }

        private void processBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tila.Focus();
        }

        private void refreshProcesses_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void deathCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            death = deathCheckBox.Checked;
            if (death)
            {
                sanoinaCheckBox.Checked = false;
                numbermodeCheckBox.Checked = false;
                hellCheckBox.Checked = false;
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }
    }

    public static class Constants
    {
        //windows message id for hotkey
        public const int WM_HOTKEY_MSG_ID = 0x0312;
    }

    public class KeyHandler
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int key;
        private IntPtr hWnd;
        private int id;

        public KeyHandler(Keys key, Form form)
        {
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, 0, key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }

    public class Keyboard
    {
    public void Send(ScanCodeShort a,bool down)
    {
        INPUT[] Inputs = new INPUT[1];
        INPUT Input = new INPUT();
        Input.type = 1; // 1 = Keyboard Input
        Input.U.ki.wScan = a;
        if (down) Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
        else Input.U.ki.dwFlags = KEYEVENTF.KEYUP | KEYEVENTF.SCANCODE;
        Inputs[0] = Input;
        SendInput(1, Inputs, INPUT.Size);
    }

    /// <summary>
    /// Declaration of external SendInput method
    /// </summary>
    [DllImport("user32.dll")]
    internal static extern uint SendInput(
        uint nInputs,
        [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs,
        int cbSize);


    // Declare the INPUT struct
    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        public uint type;
        public InputUnion U;
        public static int Size
        {
            get { return Marshal.SizeOf(typeof(INPUT)); }
        }
    }

    // Declare the InputUnion struct
    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
        [FieldOffset(0)]
        internal MOUSEINPUT mi;
        [FieldOffset(0)]
        internal KEYBDINPUT ki;
        [FieldOffset(0)]
        internal HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        internal int dx;
        internal int dy;
        internal MouseEventDataXButtons mouseData;
        internal MOUSEEVENTF dwFlags;
        internal uint time;
        internal UIntPtr dwExtraInfo;
    }

    [Flags]
    public enum MouseEventDataXButtons : uint
    {
        Nothing = 0x00000000,
        XBUTTON1 = 0x00000001,
        XBUTTON2 = 0x00000002
    }

    [Flags]
    public enum MOUSEEVENTF : uint
    {
        ABSOLUTE = 0x8000,
        HWHEEL = 0x01000,
        MOVE = 0x0001,
        MOVE_NOCOALESCE = 0x2000,
        LEFTDOWN = 0x0002,
        LEFTUP = 0x0004,
        RIGHTDOWN = 0x0008,
        RIGHTUP = 0x0010,
        MIDDLEDOWN = 0x0020,
        MIDDLEUP = 0x0040,
        VIRTUALDESK = 0x4000,
        WHEEL = 0x0800,
        XDOWN = 0x0080,
        XUP = 0x0100
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        internal VirtualKeyShort wVk;
        internal ScanCodeShort wScan;
        internal KEYEVENTF dwFlags;
        internal int time;
        internal UIntPtr dwExtraInfo;
    }

    [Flags]
    public enum KEYEVENTF : uint
    {
        EXTENDEDKEY = 0x0001,
        KEYUP = 0x0002,
        SCANCODE = 0x0008,
        UNICODE = 0x0004
    }

    public enum VirtualKeyShort : short
    {
        ///<summary>
        ///Left mouse button
        ///</summary>
        LBUTTON = 0x01,
        ///<summary>
        ///Right mouse button
        ///</summary>
        RBUTTON = 0x02,
        ///<summary>
        ///Control-break processing
        ///</summary>
        CANCEL = 0x03,
        ///<summary>
        ///Middle mouse button (three-button mouse)
        ///</summary>
        MBUTTON = 0x04,
        ///<summary>
        ///Windows 2000/XP: X1 mouse button
        ///</summary>
        XBUTTON1 = 0x05,
        ///<summary>
        ///Windows 2000/XP: X2 mouse button
        ///</summary>
        XBUTTON2 = 0x06,
        ///<summary>
        ///BACKSPACE key
        ///</summary>
        BACK = 0x08,
        ///<summary>
        ///TAB key
        ///</summary>
        TAB = 0x09,
        ///<summary>
        ///CLEAR key
        ///</summary>
        CLEAR = 0x0C,
        ///<summary>
        ///ENTER key
        ///</summary>
        RETURN = 0x0D,
        ///<summary>
        ///SHIFT key
        ///</summary>
        SHIFT = 0x10,
        ///<summary>
        ///CTRL key
        ///</summary>
        CONTROL = 0x11,
        ///<summary>
        ///ALT key
        ///</summary>
        MENU = 0x12,
        ///<summary>
        ///PAUSE key
        ///</summary>
        PAUSE = 0x13,
        ///<summary>
        ///CAPS LOCK key
        ///</summary>
        CAPITAL = 0x14,
        ///<summary>
        ///Input Method Editor (IME) Kana mode
        ///</summary>
        KANA = 0x15,
        ///<summary>
        ///IME Hangul mode
        ///</summary>
        HANGUL = 0x15,
        ///<summary>
        ///IME Junja mode
        ///</summary>
        JUNJA = 0x17,
        ///<summary>
        ///IME final mode
        ///</summary>
        FINAL = 0x18,
        ///<summary>
        ///IME Hanja mode
        ///</summary>
        HANJA = 0x19,
        ///<summary>
        ///IME Kanji mode
        ///</summary>
        KANJI = 0x19,
        ///<summary>
        ///ESC key
        ///</summary>
        ESCAPE = 0x1B,
        ///<summary>
        ///IME convert
        ///</summary>
        CONVERT = 0x1C,
        ///<summary>
        ///IME nonconvert
        ///</summary>
        NONCONVERT = 0x1D,
        ///<summary>
        ///IME accept
        ///</summary>
        ACCEPT = 0x1E,
        ///<summary>
        ///IME mode change request
        ///</summary>
        MODECHANGE = 0x1F,
        ///<summary>
        ///SPACEBAR
        ///</summary>
        SPACE = 0x20,
        ///<summary>
        ///PAGE UP key
        ///</summary>
        PRIOR = 0x21,
        ///<summary>
        ///PAGE DOWN key
        ///</summary>
        NEXT = 0x22,
        ///<summary>
        ///END key
        ///</summary>
        END = 0x23,
        ///<summary>
        ///HOME key
        ///</summary>
        HOME = 0x24,
        ///<summary>
        ///LEFT ARROW key
        ///</summary>
        LEFT = 0x25,
        ///<summary>
        ///UP ARROW key
        ///</summary>
        UP = 0x26,
        ///<summary>
        ///RIGHT ARROW key
        ///</summary>
        RIGHT = 0x27,
        ///<summary>
        ///DOWN ARROW key
        ///</summary>
        DOWN = 0x28,
        ///<summary>
        ///SELECT key
        ///</summary>
        SELECT = 0x29,
        ///<summary>
        ///PRINT key
        ///</summary>
        PRINT = 0x2A,
        ///<summary>
        ///EXECUTE key
        ///</summary>
        EXECUTE = 0x2B,
        ///<summary>
        ///PRINT SCREEN key
        ///</summary>
        SNAPSHOT = 0x2C,
        ///<summary>
        ///INS key
        ///</summary>
        INSERT = 0x2D,
        ///<summary>
        ///DEL key
        ///</summary>
        DELETE = 0x2E,
        ///<summary>
        ///HELP key
        ///</summary>
        HELP = 0x2F,
        ///<summary>
        ///0 key
        ///</summary>
        KEY_0 = 0x30,
        ///<summary>
        ///1 key
        ///</summary>
        KEY_1 = 0x31,
        ///<summary>
        ///2 key
        ///</summary>
        KEY_2 = 0x32,
        ///<summary>
        ///3 key
        ///</summary>
        KEY_3 = 0x33,
        ///<summary>
        ///4 key
        ///</summary>
        KEY_4 = 0x34,
        ///<summary>
        ///5 key
        ///</summary>
        KEY_5 = 0x35,
        ///<summary>
        ///6 key
        ///</summary>
        KEY_6 = 0x36,
        ///<summary>
        ///7 key
        ///</summary>
        KEY_7 = 0x37,
        ///<summary>
        ///8 key
        ///</summary>
        KEY_8 = 0x38,
        ///<summary>
        ///9 key
        ///</summary>
        KEY_9 = 0x39,
        ///<summary>
        ///A key
        ///</summary>
        KEY_A = 0x41,
        ///<summary>
        ///B key
        ///</summary>
        KEY_B = 0x42,
        ///<summary>
        ///C key
        ///</summary>
        KEY_C = 0x43,
        ///<summary>
        ///D key
        ///</summary>
        KEY_D = 0x44,
        ///<summary>
        ///E key
        ///</summary>
        KEY_E = 0x45,
        ///<summary>
        ///F key
        ///</summary>
        KEY_F = 0x46,
        ///<summary>
        ///G key
        ///</summary>
        KEY_G = 0x47,
        ///<summary>
        ///H key
        ///</summary>
        KEY_H = 0x48,
        ///<summary>
        ///I key
        ///</summary>
        KEY_I = 0x49,
        ///<summary>
        ///J key
        ///</summary>
        KEY_J = 0x4A,
        ///<summary>
        ///K key
        ///</summary>
        KEY_K = 0x4B,
        ///<summary>
        ///L key
        ///</summary>
        KEY_L = 0x4C,
        ///<summary>
        ///M key
        ///</summary>
        KEY_M = 0x4D,
        ///<summary>
        ///N key
        ///</summary>
        KEY_N = 0x4E,
        ///<summary>
        ///O key
        ///</summary>
        KEY_O = 0x4F,
        ///<summary>
        ///P key
        ///</summary>
        KEY_P = 0x50,
        ///<summary>
        ///Q key
        ///</summary>
        KEY_Q = 0x51,
        ///<summary>
        ///R key
        ///</summary>
        KEY_R = 0x52,
        ///<summary>
        ///S key
        ///</summary>
        KEY_S = 0x53,
        ///<summary>
        ///T key
        ///</summary>
        KEY_T = 0x54,
        ///<summary>
        ///U key
        ///</summary>
        KEY_U = 0x55,
        ///<summary>
        ///V key
        ///</summary>
        KEY_V = 0x56,
        ///<summary>
        ///W key
        ///</summary>
        KEY_W = 0x57,
        ///<summary>
        ///X key
        ///</summary>
        KEY_X = 0x58,
        ///<summary>
        ///Y key
        ///</summary>
        KEY_Y = 0x59,
        ///<summary>
        ///Z key
        ///</summary>
        KEY_Z = 0x5A,
        ///<summary>
        ///Left Windows key (Microsoft Natural keyboard) 
        ///</summary>
        LWIN = 0x5B,
        ///<summary>
        ///Right Windows key (Natural keyboard)
        ///</summary>
        RWIN = 0x5C,
        ///<summary>
        ///Applications key (Natural keyboard)
        ///</summary>
        APPS = 0x5D,
        ///<summary>
        ///Computer Sleep key
        ///</summary>
        SLEEP = 0x5F,
        ///<summary>
        ///Numeric keypad 0 key
        ///</summary>
        NUMPAD0 = 0x60,
        ///<summary>
        ///Numeric keypad 1 key
        ///</summary>
        NUMPAD1 = 0x61,
        ///<summary>
        ///Numeric keypad 2 key
        ///</summary>
        NUMPAD2 = 0x62,
        ///<summary>
        ///Numeric keypad 3 key
        ///</summary>
        NUMPAD3 = 0x63,
        ///<summary>
        ///Numeric keypad 4 key
        ///</summary>
        NUMPAD4 = 0x64,
        ///<summary>
        ///Numeric keypad 5 key
        ///</summary>
        NUMPAD5 = 0x65,
        ///<summary>
        ///Numeric keypad 6 key
        ///</summary>
        NUMPAD6 = 0x66,
        ///<summary>
        ///Numeric keypad 7 key
        ///</summary>
        NUMPAD7 = 0x67,
        ///<summary>
        ///Numeric keypad 8 key
        ///</summary>
        NUMPAD8 = 0x68,
        ///<summary>
        ///Numeric keypad 9 key
        ///</summary>
        NUMPAD9 = 0x69,
        ///<summary>
        ///Multiply key
        ///</summary>
        MULTIPLY = 0x6A,
        ///<summary>
        ///Add key
        ///</summary>
        ADD = 0x6B,
        ///<summary>
        ///Separator key
        ///</summary>
        SEPARATOR = 0x6C,
        ///<summary>
        ///Subtract key
        ///</summary>
        SUBTRACT = 0x6D,
        ///<summary>
        ///Decimal key
        ///</summary>
        DECIMAL = 0x6E,
        ///<summary>
        ///Divide key
        ///</summary>
        DIVIDE = 0x6F,
        ///<summary>
        ///F1 key
        ///</summary>
        F1 = 0x70,
        ///<summary>
        ///F2 key
        ///</summary>
        F2 = 0x71,
        ///<summary>
        ///F3 key
        ///</summary>
        F3 = 0x72,
        ///<summary>
        ///F4 key
        ///</summary>
        F4 = 0x73,
        ///<summary>
        ///F5 key
        ///</summary>
        F5 = 0x74,
        ///<summary>
        ///F6 key
        ///</summary>
        F6 = 0x75,
        ///<summary>
        ///F7 key
        ///</summary>
        F7 = 0x76,
        ///<summary>
        ///F8 key
        ///</summary>
        F8 = 0x77,
        ///<summary>
        ///F9 key
        ///</summary>
        F9 = 0x78,
        ///<summary>
        ///F10 key
        ///</summary>
        F10 = 0x79,
        ///<summary>
        ///F11 key
        ///</summary>
        F11 = 0x7A,
        ///<summary>
        ///F12 key
        ///</summary>
        F12 = 0x7B,
        ///<summary>
        ///F13 key
        ///</summary>
        F13 = 0x7C,
        ///<summary>
        ///F14 key
        ///</summary>
        F14 = 0x7D,
        ///<summary>
        ///F15 key
        ///</summary>
        F15 = 0x7E,
        ///<summary>
        ///F16 key
        ///</summary>
        F16 = 0x7F,
        ///<summary>
        ///F17 key  
        ///</summary>
        F17 = 0x80,
        ///<summary>
        ///F18 key  
        ///</summary>
        F18 = 0x81,
        ///<summary>
        ///F19 key  
        ///</summary>
        F19 = 0x82,
        ///<summary>
        ///F20 key  
        ///</summary>
        F20 = 0x83,
        ///<summary>
        ///F21 key  
        ///</summary>
        F21 = 0x84,
        ///<summary>
        ///F22 key, (PPC only) Key used to lock device.
        ///</summary>
        F22 = 0x85,
        ///<summary>
        ///F23 key  
        ///</summary>
        F23 = 0x86,
        ///<summary>
        ///F24 key  
        ///</summary>
        F24 = 0x87,
        ///<summary>
        ///NUM LOCK key
        ///</summary>
        NUMLOCK = 0x90,
        ///<summary>
        ///SCROLL LOCK key
        ///</summary>
        SCROLL = 0x91,
        ///<summary>
        ///Left SHIFT key
        ///</summary>
        LSHIFT = 0xA0,
        ///<summary>
        ///Right SHIFT key
        ///</summary>
        RSHIFT = 0xA1,
        ///<summary>
        ///Left CONTROL key
        ///</summary>
        LCONTROL = 0xA2,
        ///<summary>
        ///Right CONTROL key
        ///</summary>
        RCONTROL = 0xA3,
        ///<summary>
        ///Left MENU key
        ///</summary>
        LMENU = 0xA4,
        ///<summary>
        ///Right MENU key
        ///</summary>
        RMENU = 0xA5,
        ///<summary>
        ///Windows 2000/XP: Browser Back key
        ///</summary>
        BROWSER_BACK = 0xA6,
        ///<summary>
        ///Windows 2000/XP: Browser Forward key
        ///</summary>
        BROWSER_FORWARD = 0xA7,
        ///<summary>
        ///Windows 2000/XP: Browser Refresh key
        ///</summary>
        BROWSER_REFRESH = 0xA8,
        ///<summary>
        ///Windows 2000/XP: Browser Stop key
        ///</summary>
        BROWSER_STOP = 0xA9,
        ///<summary>
        ///Windows 2000/XP: Browser Search key 
        ///</summary>
        BROWSER_SEARCH = 0xAA,
        ///<summary>
        ///Windows 2000/XP: Browser Favorites key
        ///</summary>
        BROWSER_FAVORITES = 0xAB,
        ///<summary>
        ///Windows 2000/XP: Browser Start and Home key
        ///</summary>
        BROWSER_HOME = 0xAC,
        ///<summary>
        ///Windows 2000/XP: Volume Mute key
        ///</summary>
        VOLUME_MUTE = 0xAD,
        ///<summary>
        ///Windows 2000/XP: Volume Down key
        ///</summary>
        VOLUME_DOWN = 0xAE,
        ///<summary>
        ///Windows 2000/XP: Volume Up key
        ///</summary>
        VOLUME_UP = 0xAF,
        ///<summary>
        ///Windows 2000/XP: Next Track key
        ///</summary>
        MEDIA_NEXT_TRACK = 0xB0,
        ///<summary>
        ///Windows 2000/XP: Previous Track key
        ///</summary>
        MEDIA_PREV_TRACK = 0xB1,
        ///<summary>
        ///Windows 2000/XP: Stop Media key
        ///</summary>
        MEDIA_STOP = 0xB2,
        ///<summary>
        ///Windows 2000/XP: Play/Pause Media key
        ///</summary>
        MEDIA_PLAY_PAUSE = 0xB3,
        ///<summary>
        ///Windows 2000/XP: Start Mail key
        ///</summary>
        LAUNCH_MAIL = 0xB4,
        ///<summary>
        ///Windows 2000/XP: Select Media key
        ///</summary>
        LAUNCH_MEDIA_SELECT = 0xB5,
        ///<summary>
        ///Windows 2000/XP: Start Application 1 key
        ///</summary>
        LAUNCH_APP1 = 0xB6,
        ///<summary>
        ///Windows 2000/XP: Start Application 2 key
        ///</summary>
        LAUNCH_APP2 = 0xB7,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_1 = 0xBA,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '+' key
        ///</summary>
        OEM_PLUS = 0xBB,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the ',' key
        ///</summary>
        OEM_COMMA = 0xBC,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '-' key
        ///</summary>
        OEM_MINUS = 0xBD,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '.' key
        ///</summary>
        OEM_PERIOD = 0xBE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_2 = 0xBF,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_3 = 0xC0,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_4 = 0xDB,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_5 = 0xDC,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_6 = 0xDD,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_7 = 0xDE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_8 = 0xDF,
        ///<summary>
        ///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
        ///</summary>
        OEM_102 = 0xE2,
        ///<summary>
        ///Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
        ///</summary>
        PROCESSKEY = 0xE5,
        ///<summary>
        ///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes.
        ///The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information,
        ///see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        ///</summary>
        PACKET = 0xE7,
        ///<summary>
        ///Attn key
        ///</summary>
        ATTN = 0xF6,
        ///<summary>
        ///CrSel key
        ///</summary>
        CRSEL = 0xF7,
        ///<summary>
        ///ExSel key
        ///</summary>
        EXSEL = 0xF8,
        ///<summary>
        ///Erase EOF key
        ///</summary>
        EREOF = 0xF9,
        ///<summary>
        ///Play key
        ///</summary>
        PLAY = 0xFA,
        ///<summary>
        ///Zoom key
        ///</summary>
        ZOOM = 0xFB,
        ///<summary>
        ///Reserved 
        ///</summary>
        NONAME = 0xFC,
        ///<summary>
        ///PA1 key
        ///</summary>
        PA1 = 0xFD,
        ///<summary>
        ///Clear key
        ///</summary>
        OEM_CLEAR = 0xFE
    }

    public enum ScanCodeShort : short
    {
        LBUTTON = 0,
        RBUTTON = 0,
        CANCEL = 70,
        MBUTTON = 0,
        XBUTTON1 = 0,
        XBUTTON2 = 0,
        BACK = 14,
        TAB = 15,
        CLEAR = 76,
        RETURN = 28,
        SHIFT = 42,
        CONTROL = 29,
        MENU = 56,
        PAUSE = 0,
        CAPITAL = 58,
        KANA = 0,
        HANGUL = 0,
        JUNJA = 0,
        FINAL = 0,
        HANJA = 0,
        KANJI = 0,
        ESCAPE = 1,
        CONVERT = 0,
        NONCONVERT = 0,
        ACCEPT = 0,
        MODECHANGE = 0,
        SPACE = 57,
        PRIOR = 73,
        NEXT = 81,
        END = 79,
        HOME = 71,
        LEFT = 75,
        UP = 72,
        RIGHT = 77,
        DOWN = 80,
        SELECT = 0,
        PRINT = 0,
        EXECUTE = 0,
        SNAPSHOT = 84,
        INSERT = 82,
        DELETE = 83,
        HELP = 99,
        KEY_0 = 11,
        KEY_1 = 2,
        KEY_2 = 3,
        KEY_3 = 4,
        KEY_4 = 5,
        KEY_5 = 6,
        KEY_6 = 7,
        KEY_7 = 8,
        KEY_8 = 9,
        KEY_9 = 10,
        KEY_A = 30,
        KEY_B = 48,
        KEY_C = 46,
        KEY_D = 32,
        KEY_E = 18,
        KEY_F = 33,
        KEY_G = 34,
        KEY_H = 35,
        KEY_I = 23,
        KEY_J = 36,
        KEY_K = 37,
        KEY_L = 38,
        KEY_M = 50,
        KEY_N = 49,
        KEY_O = 24,
        KEY_P = 25,
        KEY_Q = 16,
        KEY_R = 19,
        KEY_S = 31,
        KEY_T = 20,
        KEY_U = 22,
        KEY_V = 47,
        KEY_W = 17,
        KEY_X = 45,
        KEY_Y = 21,
        KEY_Z = 44,
        LWIN = 91,
        RWIN = 92,
        APPS = 93,
        SLEEP = 95,
        NUMPAD0 = 82,
        NUMPAD1 = 79,
        NUMPAD2 = 80,
        NUMPAD3 = 81,
        NUMPAD4 = 75,
        NUMPAD5 = 76,
        NUMPAD6 = 77,
        NUMPAD7 = 71,
        NUMPAD8 = 72,
        NUMPAD9 = 73,
        MULTIPLY = 55,
        ADD = 78,
        SEPARATOR = 0,
        SUBTRACT = 74,
        DECIMAL = 83,
        DIVIDE = 53,
        F1 = 59,
        F2 = 60,
        F3 = 61,
        F4 = 62,
        F5 = 63,
        F6 = 64,
        F7 = 65,
        F8 = 66,
        F9 = 67,
        F10 = 68,
        F11 = 87,
        F12 = 88,
        F13 = 100,
        F14 = 101,
        F15 = 102,
        F16 = 103,
        F17 = 104,
        F18 = 105,
        F19 = 106,
        F20 = 107,
        F21 = 108,
        F22 = 109,
        F23 = 110,
        F24 = 118,
        NUMLOCK = 69,
        SCROLL = 70,
        LSHIFT = 42,
        RSHIFT = 54,
        LCONTROL = 29,
        RCONTROL = 29,
        LMENU = 56,
        RMENU = 56,
        BROWSER_BACK = 106,
        BROWSER_FORWARD = 105,
        BROWSER_REFRESH = 103,
        BROWSER_STOP = 104,
        BROWSER_SEARCH = 101,
        BROWSER_FAVORITES = 102,
        BROWSER_HOME = 50,
        VOLUME_MUTE = 32,
        VOLUME_DOWN = 46,
        VOLUME_UP = 48,
        MEDIA_NEXT_TRACK = 25,
        MEDIA_PREV_TRACK = 16,
        MEDIA_STOP = 36,
        MEDIA_PLAY_PAUSE = 34,
        LAUNCH_MAIL = 108,
        LAUNCH_MEDIA_SELECT = 109,
        LAUNCH_APP1 = 107,
        LAUNCH_APP2 = 33,
        OEM_1 = 39,
        OEM_PLUS = 13,
        OEM_COMMA = 51,
        OEM_MINUS = 12,
        OEM_PERIOD = 52,
        OEM_2 = 53,
        OEM_3 = 41,
        OEM_4 = 26,
        OEM_5 = 43,
        OEM_6 = 27,
        OEM_7 = 40,
        OEM_8 = 0,
        OEM_102 = 86,
        PROCESSKEY = 0,
        PACKET = 0,
        ATTN = 0,
        CRSEL = 0,
        EXSEL = 0,
        EREOF = 93,
        PLAY = 0,
        ZOOM = 98,
        NONAME = 0,
        PA1 = 0,
        OEM_CLEAR = 0,
    }

    /// <summary>
    /// Define HARDWAREINPUT struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        internal int uMsg;
        internal short wParamL;
        internal short wParamH;
    }
}
}