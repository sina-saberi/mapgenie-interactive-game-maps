import readline from 'readline';
import chalk from 'chalk';

type SelectProps = Record<string, () => void>;

export const select = (props: SelectProps) => {
    let selectedOption = 0;
    const keys = Object.keys(props);

    console.clear();
    const rl = readline.createInterface({
        input: process.stdin,
        output: process.stdout,
        terminal: true
    });

    readline.emitKeypressEvents(process.stdin);
    process.stdin.setRawMode(true);

    const logOptions = () => {
        console.clear();
        console.log('Select one option:');
        keys.forEach((x, index) => {
            if (index === selectedOption) {
                console.log(chalk.green(`> ${x}`)); // Highlight selected option
            } else {
                console.log(`  ${x}`);
            }
        });
    };

    logOptions();

    process.stdin.on('keypress', (str, key) => {
        if (key.name === 'up') {
            selectedOption = (selectedOption - 1 + keys.length) % keys.length;
            logOptions();
        } else if (key.name === 'down') {
            selectedOption = (selectedOption + 1) % keys.length;
            logOptions();
        } else if (key.name === 'return') {
            if (keys[selectedOption]) {
                props[keys[selectedOption]]();
            }
            // rl.close(); // Close the readline interface
            // process.stdin.setRawMode(false); // Reset the terminal mode
            // process.stdin.pause(); // Pause the input stream
        }
    });

    // Handle exit with Ctrl+C
    rl.on('SIGINT', () => {
        rl.close();
        process.stdin.setRawMode(false);
        process.stdin.pause();
    });
};