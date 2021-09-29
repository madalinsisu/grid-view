import './App.css';
import { useEffect, useState } from 'react';
import { DepositsComponent } from './components/Deposits';
import Dropdown, { Option } from 'react-dropdown';
import 'react-dropdown/style.css';
import { OperationTypeModel } from './shared/models/operation-type.model';
import { HttpService } from './services/http.service';
import { SelectItemConfig } from './shared/config/select-item.config';
import { Helper } from './shared/helper';
import { WithdrawalsComponent } from './components/Withdrawal';
import { TradeOrdersComponent } from './components/TradeOrder';


function App() {
  const initialState: { options: SelectItemConfig[], selectedOption: SelectItemConfig | null } =
    { options: [], selectedOption: null };

  const [state, setState] =
    useState<{ options: SelectItemConfig[], selectedOption: SelectItemConfig | null }>(initialState);

  useEffect(() => {
    new HttpService<OperationTypeModel>("operation-types").getEntities().then(data => {
      setState({ ...state, options: data.map(Helper.OperationTypeToSelectItem) });
      console.log(data);
    })
  }, []);

  function onSelect(arg: Option) {
    setState({ ...state, selectedOption: { label: (arg.label as string), value: arg.value } })
    console.log(state);
  }

  const displayTable = () => {
    switch (state.selectedOption?.value) {

      case "1": return <DepositsComponent />;
      case "2": return <WithdrawalsComponent />;
      case "3": return <TradeOrdersComponent />;

      default: return <h3>Nothing to display</h3>
    }
  }

  return (
    <div className="App">
      <Dropdown options={state.options} value={state.selectedOption?.label} onChange={onSelect} placeholder="Select an option" />
      {displayTable()}
    </div>
  );
}

export default App;
