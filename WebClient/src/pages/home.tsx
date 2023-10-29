import { useState, useEffect } from 'react';
import axios from 'axios';

import Header from '@/components/header';
import Footer from '@/components/footer';

interface Theme {
    id: number;
    themeName: string;
    createDate: string;
    modifierDate: string;
}

export default function HomePage() {
    const [themes, setThemes] = useState<Theme[] | null>(null);

    useEffect(() => {
        axios
            .get('/api/theme')
            .then((res) => {
                setThemes(res.data);
            })
            .catch((err) => {
                console.log(err);
            });
    }, []);

    if (!themes) {
        return <div>Loading...</div>;
    }

    return (
        <>
            <Header />
            <section>
                <div className="mx-auto max-w-screen-xl px-4 py-32 lg:flex lg:h-screen lg:items-center">
                    <div className="mx-auto max-w-xl text-center">
                        <h1 className="text-3xl font-extrabold sm:text-5xl">
                            Understand User Flow.
                            <strong className="font-extrabold text-red-700 sm:block">
                                Increase Conversion.
                            </strong>
                        </h1>

                        <p className="mt-4 sm:text-xl/relaxed">
                            Lorem ipsum dolor sit amet consectetur, adipisicing
                            elit. Nesciunt illo tenetur fuga ducimus numquam ea!
                        </p>

                        <div className="mt-8 flex flex-wrap justify-center gap-4">
                            <a
                                className="block w-full rounded bg-red-600 px-12 py-3 text-sm font-medium text-white shadow hover:bg-red-700 focus:outline-none focus:ring active:bg-red-500 sm:w-auto"
                                href="/get-started"
                            >
                                Get Started
                            </a>

                            <a
                                className="block w-full rounded px-12 py-3 text-sm font-medium text-red-600 shadow hover:text-red-700 focus:outline-none focus:ring active:text-red-500 sm:w-auto"
                                href="/about"
                            >
                                Learn More
                            </a>
                        </div>
                    </div>
                </div>
            </section>
            <div className="container">
                <ul>
                    {themes.map((theme) => (
                        <li key={theme.id}>{theme.themeName}</li>
                    ))}
                </ul>
            </div>
            <Footer />
        </>
    );
}
