import readline from 'node:readline';
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});

export const input = (question: string) => new Promise<string>((resolve) => {
    rl.question(question, ans => {
        resolve(ans);
        rl.close();
    });
})