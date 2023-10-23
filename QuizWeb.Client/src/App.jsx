import { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { themes: [], loading: true };
    }

    componentDidMount() {
        this.themeData();
    }

    static renderThemesTable(themes) {
        return (
            <div className="overflow-x-auto rounded-lg border border-gray-200">
                <table className="min-w-full divide-y-2 divide-gray-200 bg-white text-sm">
                    <thead className="ltr:text-left rtl:text-right">
                        <tr>
                            <th className="whitespace-nowrap px-4 py-2 font-medium text-gray-900">
                                Theme Name
                            </th>
                            <th className="whitespace-nowrap px-4 py-2 font-medium text-gray-900">
                                Created Date
                            </th>
                            <th className="whitespace-nowrap px-4 py-2 font-medium text-gray-900">
                                Modifier Date
                            </th>
                        </tr>
                    </thead>

                    <tbody className="divide-y divide-gray-200">
                        {themes.map((theme) => (
                            <tr key={theme.id}>
                                <td className="whitespace-nowrap px-4 py-2 font-medium text-gray-900">
                                    {theme.themeName}
                                </td>
                                <td className="whitespace-nowrap px-4 py-2 text-gray-700">
                                    {theme.createDate}
                                </td>
                                <td className="whitespace-nowrap px-4 py-2 text-gray-700">
                                    {theme.modifierDate}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading ? (
            <p>
                <em>
                    Loading... Please refresh once the ASP.NET backend has
                    started. See{' '}
                    <a href="https://aka.ms/jspsintegrationreact">
                        https://aka.ms/jspsintegrationreact
                    </a>{' '}
                    for more details.
                </em>
            </p>
        ) : (
            App.renderThemesTable(this.state.themes)
        );

        return (
            <div className="max-w-screen-md min-h-screen mx-auto">
                <h1 className="text-4xl font-bold">Quiz Web</h1>
                <p className="text-md mb-4">
                    This component demonstrates fetching data from the server.
                </p>
                {contents}
            </div>
        );
    }

    async themeData() {
        const response = await fetch('api/theme');
        const data = await response.json();
        this.setState({ themes: data, loading: false });
    }
}
