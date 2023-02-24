namespace WithTask4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        async private void button1_Click(object sender, EventArgs e)
        {
            var x = textBox1.Text;
            var y = textBox2.Text;


            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("x", x),
                new KeyValuePair<string, string>("y", y)
            });

            HttpClient client = new HttpClient();
            var res = await client.PostAsync("https://localhost:44394/sum", formContent);
            textBox3.Text = await res.Content.ReadAsStringAsync();
        }
    }
}