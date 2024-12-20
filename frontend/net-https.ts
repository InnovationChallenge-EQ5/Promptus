import * as path from "path";
import * as fs from "fs";
import {spawn} from "child_process";
import sleep from "thread-sleep";

export const certificate = {
    certFilePath: '',
    keyFilePath: ''
}

if (process.env.NODE_ENV === 'development') {
    const baseFolder = process.env.APPDATA !== undefined && process.env.APPDATA !== ''
        ? `${process.env.APPDATA}/ASP.NET/https`
        : `${process.env.HOME}/.aspnet/https`;

    const certificateArg = process.argv.map(arg => arg.match(/--name=(?<value>.+)/i)).filter(Boolean)[0];
    const certificateName = certificateArg ? certificateArg.groups?.value : process.env.npm_package_name;

    if (!certificateName) {
        console.error('Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly.')
        process.exit(-1);
    }

    certificate.certFilePath = path.join(baseFolder, `${certificateName}.pem`);
    certificate.keyFilePath = path.join(baseFolder, `${certificateName}.key`);

    if (!fs.existsSync(certificate.certFilePath) || !fs.existsSync(certificate.keyFilePath)) {
        spawn('dotnet', [
            'dev-certs',
            'https',
            '-ep',
            certificate.certFilePath,
            '--format',
            'PEM',
            '--no-password',
        ], {stdio: 'inherit',})
            .on('exit', code => {
                if (code === 0) {
                    console.log('Certificate created successfully.');
                } else {
                    console.error('Error creating certificate.');
                }
            });

       /* while (!fs.existsSync(certificate.certFilePath)) {
            sleep(1000);
        } **/
    }
}
